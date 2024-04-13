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
        float x = ((float)level - 1) / (maxLevel - 1);
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

    public void ApplyMultiplicativeModifier(StatType type, Modifier modifier) {
        _stats[type].multiplicativeModifiers.Add(modifier);
    }

    public void ApplyAdditiveModifier(StatType type, Modifier modifier) {
        _stats[type].additiveModifers.Add(modifier);
    }

    public void RemoveMultiplicativeModifier(StatType type, Modifier modifier) {
        _stats[type].multiplicativeModifiers.Remove(modifier);
    }

    public void RemoveAdditiveModifier(StatType type, Modifier modifier) {
        _stats[type].additiveModifers.Remove(modifier);
    }

}