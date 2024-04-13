using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public record ElementalStats
{
    public float cooldown;
    public int damage;
    public float speed;
    public float range;
}

public class ElementalCreature : MonoBehaviour
{
    public ElementalStats stats;
}
