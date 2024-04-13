using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Summons {
    public GameObject prefab;
    public ElementalStats stats;
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
                elemental.cooldown = elemental.stats.cooldown;
                SpawnElemental(elemental.prefab, elemental.stats);
            }
        }
    }

    void SpawnElemental(GameObject prefab, ElementalStats stats) {
        Vector3 pos = transform.position + Vector3.right * transform.localScale.x * distance;
        Debug.Log(pos);
        GameObject elemental = Instantiate(prefab, pos, Quaternion.identity);
        elemental.GetComponent<ElementalCreature>().stats = stats with { };
    }
}
