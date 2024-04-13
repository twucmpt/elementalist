using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefab;
    public void Spawn() {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
