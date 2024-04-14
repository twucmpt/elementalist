using System.Collections.Generic;
using UnityEngine;

public class StaticStats : Stats {
    public StaticStats(Dictionary<StatType, float> stats) {
        staticStats = stats;
    }
    public Dictionary<StatType, float> staticStats;
    override public float GetStat(StatType type, int? level = null) {
        return staticStats[type];
    }
}
public class Projectile : MonoBehaviour
{
    public Stats stats;
}
