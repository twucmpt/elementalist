using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Summons {
    public GameObject prefab;
    public float cooldown;
}

public class SummonElementals : MonoBehaviour
{
    public float distance;
    public List<Summons> elementals = new List<Summons>();

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
    }
}
