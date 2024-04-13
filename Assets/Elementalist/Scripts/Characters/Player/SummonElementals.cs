using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Summons {
    public GameObject prefab;
    public float cooldown = float.PositiveInfinity;
}

public class SummonElementals : MonoBehaviour
{
    public float distance;
    public List<Summons> elementals = new List<Summons>();
    public GameObject spawnAnimation;

    void Start() {
        foreach (Summons elemental in elementals) {
            elemental.cooldown = elemental.prefab.GetComponent<ElementalCreature>().stats.GetStat(StatType.Cooldown) + UnityEngine.Random.Range(-1f, 1f);
        }
    }

    void Update() {
        foreach (Summons elemental in elementals) {
            elemental.cooldown -= Time.deltaTime;
            if (elemental.cooldown <= 0) {
                elemental.cooldown = elemental.prefab.GetComponent<ElementalCreature>().stats.GetStat(StatType.Cooldown);
                SpawnElemental(elemental.prefab);
            }
        }
    }

    void SpawnElemental(GameObject prefab) {
        Vector3 pos = transform.position + Vector3.right * transform.localScale.x * distance;
        GameObject elemental = Instantiate(prefab, pos, Quaternion.identity);
        elemental.SetActive(false);
        Instantiate(spawnAnimation, pos + Vector3.down * 0.1f, Quaternion.identity);
        // Not the best place to do this, but leaving it here for now
        StartCoroutine(DelaySpawn(elemental, 1f));
    }

    IEnumerator DelaySpawn(GameObject elemental, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        // we'll need to check for player death here
        elemental.SetActive(true);
    }
 
    public void UpsertElemental(ElementalType type) {
        //Summons newElemental = new Summons();
        //newElemental.prefab = prefab;
        //newElemental.cooldown = prefab.GetComponent<ElementalCreature>().stats.GetStat(StatType.Cooldown);
        //elementals.Add(newElemental);
        Console.WriteLine("Upserting " + type);
    }

}
