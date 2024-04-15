using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMagma : MonoBehaviour
{
    public float frequency;
    public GameObject prefab;
    private float count;

    void Update()
    {
        count -= Time.deltaTime;
        if (count < 0) {
            count = frequency;
            GameObject magma = Instantiate(prefab, transform.position, Quaternion.identity);
            magma.GetComponent<MagmaCloud>().stats = GetComponent<SandProjectile>().stats;
        }

    }
}
