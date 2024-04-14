using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnXP : MonoBehaviour
{
    public GameObject prefab;
    public void Spawn() {
        GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);
        try {
            obj.GetComponent<XP>().xp = GetComponent<Health>().rewardAmount;
        }
        catch {}
    }
}
