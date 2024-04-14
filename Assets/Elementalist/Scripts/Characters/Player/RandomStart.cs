using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStart : MonoBehaviour
{
    void Awake()
    {
        transform.position = new Vector3(Random.Range(-64f,64f), Random.Range(-64f,64f), 0f);
    }
}
