using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyCatalogEntry {
    public GameObject enemy;
    public float cost;
    public float weight;
    public float minTime;
}


[Serializable]
public record EnemyDirectorSettings {
    public float initalPointRate;
    public float pointRateMultiplier = 0.01f;
    public float initalMinPoints;
    public float minPointsMultiplier = 0.1f;

    public float maxPoints;
    public float chanceToSpawnWave;

    public float maxPointRate;
    public List<EnemyCatalogEntry> enemyCatalog;
}

public class EnemyDirector : MonoBehaviour
{
    public float points;
    public float pointRate;
    public float minPoints;
    public EnemyDirectorSettings settings;
    public PlayerLeveling playerLeveling;
    public Camera mainCamera;
    private float time = 0;

    void Start() {
        OnDifficultyChanged();
        settings.enemyCatalog.Sort(delegate(EnemyCatalogEntry e1, EnemyCatalogEntry e2) { return e1.cost.CompareTo(e2.cost); });
    }

    public void OnDifficultyChanged() {
        settings = GameManager.instance.GetDifficultySetting().enemyDirectorSettings with {};
    }

    void Update()
    {
        time += Time.deltaTime;
        points += pointRate * Time.deltaTime;
        if (points > minPoints & (points > settings.maxPoints | UnityEngine.Random.Range(0f,1f) <= settings.chanceToSpawnWave)) {
            SpawnWave();
        }

        pointRate = Math.Min(settings.maxPointRate, settings.initalPointRate + settings.pointRateMultiplier * time * time);
        minPoints = Math.Min(settings.maxPoints, settings.initalMinPoints + settings.minPointsMultiplier * time * time);

    }

    void SpawnWave() {
        int enemiesPerWave = UnityEngine.Random.Range(1,6);
        while (points > minPoints & enemiesPerWave > 0) {
            EnemyCatalogEntry selectedEnemy = SelectEnemy();
            if (selectedEnemy == null) break;
            if (selectedEnemy.minTime > time) continue;
            selectedEnemy.enemy.GetComponent<Health>().SetRewardee(playerLeveling);
            int quantity = System.Math.Min((int)(points/selectedEnemy.cost),3);
            for (int i = 0; i < quantity; i++) {
                enemiesPerWave -= 1;
                SpawnEnemy(selectedEnemy);
            }
        }
    }

    void SpawnEnemy(EnemyCatalogEntry enemy) {
        Vector3 pos = GetRandomOffscreenPosition();
        Instantiate(enemy.enemy, pos, Quaternion.identity);
        points -= enemy.cost;
    }

    EnemyCatalogEntry SelectEnemy() {
        float totalWeight = 0f;
        foreach (EnemyCatalogEntry enemy in settings.enemyCatalog) {
            if (enemy.cost > points) break;
            totalWeight += enemy.weight;
        }
        if (totalWeight == 0f) return null;

        float currentWeight = 0f;
        float chosenWeight = UnityEngine.Random.Range(0f, totalWeight);
        foreach (EnemyCatalogEntry enemy in settings.enemyCatalog) {
            currentWeight += enemy.weight;
            if (currentWeight >= chosenWeight) return enemy;
        }
        // Should not get here
        return null;
    }


  private Vector3 GetRandomOffscreenPosition()
  {
    float randomSide = UnityEngine.Random.Range(0.0f, 1.0f);
    float randomX, randomY;

    // Choose a random side of the screen
    if (randomSide < 0.25f)
    {
      // Left side
      randomX = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f)).x - 1.0f;
      randomY = UnityEngine.Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y, mainCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y);
    }
    else if (randomSide < 0.5f)
    {
      // Right side
      randomX = mainCamera.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f)).x + 1.0f;
      randomY = UnityEngine.Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y, mainCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y);
    }
    else if (randomSide < 0.75f)
    {
      // Top side
      randomX = UnityEngine.Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f)).x, mainCamera.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f)).x);
      randomY = mainCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y + 1.0f;
    }
    else
    {
      // Bottom side
      randomX = UnityEngine.Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f)).x, mainCamera.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f)).x);
      randomY = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y - 1.0f;
    }

    return new Vector3(randomX, randomY, 0f);
  }
}
