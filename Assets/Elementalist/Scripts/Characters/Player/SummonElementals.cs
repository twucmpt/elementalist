using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Summons {
    public GameObject prefab;
    public float cooldown = float.PositiveInfinity;
    public int level = 1;
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
 
    public void UpsertElemental(GameObject prefab) {
        Summons elemental = elementals.Find(e => e.prefab == prefab);
        if (elemental == null) {
            ElementalCreature creature = prefab.GetComponent<ElementalCreature>();
            elementals.Add( new Summons { 
                prefab = prefab,
                cooldown = creature.stats.GetStat(StatType.Cooldown, 1),
                level = 1
            });
        }
        else {
            ElementalCreature creature = elemental.prefab.GetComponent<ElementalCreature>();
            levelUp(elemental);
        }
    }

    public void levelUp(Summons elemental ) {
        elemental.level = Mathf.Min(elemental.level + 1, elemental.prefab.GetComponent<ElementalCreature>().stats.maxLevel);
    }
}
