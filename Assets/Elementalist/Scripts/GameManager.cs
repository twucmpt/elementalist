using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;

    void Awake() {
        instance = this;
    }
}

public enum DamageType {
    Untyped,
    Fire,
    Water,
    Earth,
    Air,
    Lightning,
    Poison,
    Blood,
    Ice
}