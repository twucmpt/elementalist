using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyCatalogEntry {
    public GameObject enemy;
    public float cost;
    public float weight;
}

public class EnemyDirector : MonoBehaviour
{
    public float points;
    public float pointRate;
    public float minPoints;
    public float maxPoints;
    public float chanceToSpawnWave;
    public List<EnemyCatalogEntry> enemyCatalog;
    public Camera mainCamera;

    void Start() {
        enemyCatalog.Sort(delegate(EnemyCatalogEntry e1, EnemyCatalogEntry e2) { return e1.cost.CompareTo(e2.cost); });
    }

    void Update()
    {
        points += pointRate * Time.deltaTime;
        if (points > minPoints & (points > maxPoints | Random.Range(0f,1f) <= chanceToSpawnWave)) {
            SpawnWave();
        }

        // Temp scaling mechnaism
        pointRate += Time.deltaTime * 0.01f;
        minPoints += Time.deltaTime * 0.1f;

    }

    void SpawnWave() {
        int enemiesPerWave = Random.Range(1,6);
        while (points > minPoints & enemiesPerWave > 0) {
            EnemyCatalogEntry selectedEnemy = SelectEnemy();
            if (selectedEnemy == null) break;
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
        foreach (EnemyCatalogEntry enemy in enemyCatalog) {
            if (enemy.cost > points) break;
            totalWeight += enemy.weight;
        }
        if (totalWeight == 0f) return null;

        float currentWeight = 0f;
        float chosenWeight = Random.Range(0f, totalWeight);
        foreach (EnemyCatalogEntry enemy in enemyCatalog) {
            currentWeight += enemy.weight;
            if (currentWeight >= chosenWeight) return enemy;
        }
        // Should not get here
        return null;
    }


  private Vector3 GetRandomOffscreenPosition()
  {
    float randomSide = Random.Range(0.0f, 1.0f);
    float randomX, randomY;

    // Choose a random side of the screen
    if (randomSide < 0.25f)
    {
      // Left side
      randomX = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f)).x - 1.0f;
      randomY = Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y, mainCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y);
    }
    else if (randomSide < 0.5f)
    {
      // Right side
      randomX = mainCamera.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f)).x + 1.0f;
      randomY = Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y, mainCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y);
    }
    else if (randomSide < 0.75f)
    {
      // Top side
      randomX = Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f)).x, mainCamera.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f)).x);
      randomY = mainCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y + 1.0f;
    }
    else
    {
      // Bottom side
      randomX = Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f)).x, mainCamera.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f)).x);
      randomY = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y - 1.0f;
    }

    return new Vector3(randomX, randomY, 0f);
  }
}
