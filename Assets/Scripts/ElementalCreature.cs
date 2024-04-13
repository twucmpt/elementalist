using System;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    Cooldown,
    MovementSpeed,
    Damage,
    Range
}

[Serializable]
public class Stat
{
    public StatType type;
    public AnimationCurve scaling;
    public float scaleFactor;
    public float offset;
    public bool reverse;

    public float GetValue(int level, int maxLevel)
    {
        float x = ((float)level - 1) / (maxLevel - 1);
        if (reverse) x = 1 - x;
        return scaling.Evaluate(x) * scaleFactor + offset;
    }
}

public class ElementalCreature : MonoBehaviour
{
    public int maxLevel;
    public int level = 1;

    [SerializeField]
    private List<Stat> __stats;

    private Dictionary<StatType, Stat> _stats;

    void Start() {
        InitDictionary();
    }

    void InitDictionary() {
        if (_stats != null) return;
        _stats = new Dictionary<StatType, Stat>();
        foreach (Stat stat in __stats) {
            _stats[stat.type] = stat;
        }
    }

    public float GetStat(StatType type) {
        InitDictionary();
        return _stats[type].GetValue(level, maxLevel);
    }

}