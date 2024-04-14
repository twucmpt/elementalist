using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAtPlayer : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        transform.position = player.position;
    }
}
