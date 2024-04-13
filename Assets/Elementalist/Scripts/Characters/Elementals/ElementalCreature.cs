using System;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    Cooldown,
    MovementSpeed,
    Damage,
    Range,
    EffectStrength,
    EffectCooldown
}

[Serializable]
public class Modifier {
    public Modifier(float v) {
        value = v;
    }
    public float value;
}

[Serializable]
public class Stat
{
    public StatType type;
    public AnimationCurve scaling;
    public float scaleFactor;
    public float offset;
    public bool reverse;

    public List<Modifier> multiplicativeModifiers = new List<Modifier>();
    public List<Modifier> additiveModifers = new List<Modifier>();

    public float GetValue(int level, int maxLevel)
    {
        float x = maxLevel == 1 ? 0 : ((float)level - 1) / (maxLevel - 1);
        if (reverse) x = 1 - x;
        float value = scaling.Evaluate(x) * scaleFactor + offset;

        foreach (Modifier multiplier in multiplicativeModifiers) {
            value *= multiplier.value;
        }
        foreach (Modifier modifier in additiveModifers) {
            value += modifier.value;
        }
        return value;
    }
}

[Serializable]
public class Stats {
    public int maxLevel = 7;
    public int level = 1;
    public Dictionary<StatType, Stat> stats;

    public float GetStat(StatType type) {
        return stats[type].GetValue(level, maxLevel);
    }

    public void ApplyMultiplicativeModifier(StatType type, Modifier modifier) {
        stats[type].multiplicativeModifiers.Add(modifier);
    }

    public void ApplyAdditiveModifier(StatType type, Modifier modifier) {
        stats[type].additiveModifers.Add(modifier);
    }

    public void RemoveMultiplicativeModifier(StatType type, Modifier modifier) {
        stats[type].multiplicativeModifiers.Remove(modifier);
    }

    public void RemoveAdditiveModifier(StatType type, Modifier modifier) {
        stats[type].additiveModifers.Remove(modifier);
    }

    public void InitializeScalingStats(List<Stat> scalingStats) {
        stats = new Dictionary<StatType, Stat>();
        foreach (Stat stat in scalingStats) {
            stats[stat.type] = stat;
        }
    }
}

public class ElementalCreature : MonoBehaviour
{

    [SerializeField]
    private Stats _stats;
    [SerializeField]
    private List<Stat> scalingStats;

    public Stats stats {get {
        if (_stats.stats == null) _stats.InitializeScalingStats(scalingStats);
        return _stats;
    }}

    void Start() {
        if (_stats.stats == null) _stats.InitializeScalingStats(scalingStats);
    }
}