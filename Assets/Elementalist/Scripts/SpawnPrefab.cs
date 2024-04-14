using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefab;
    public void Spawn() {
        GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);
        try {
            obj.GetComponent<Projectile>().stats = gameObject.GetComponent<ElementalCreature>().stats;
        }
        catch {}
    }
}
