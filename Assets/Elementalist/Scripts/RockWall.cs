using System;
using System.Collections.Generic;
using UnityEngine;

public class RockWall : Projectile
{
    public List<GameObject> levels;
    void Start()
    {
        int level = Math.Min(Mathf.RoundToInt(stats.GetStat(StatType.EffectStrength)), levels.Count-1);
        levels[level].SetActive(true);
    }
}
