using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusEffects {
    SlowEffect,
    DamageOverTimeEffect
}

public class StatusEffect : MonoBehaviour
{
    public ElementalCreature origin;
    public float cooldown = float.PositiveInfinity;
    public virtual void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0) Destroy(this);
    }

    public static Dictionary<StatusEffects, Type> effectsMap = new Dictionary<StatusEffects, Type>() {
        {StatusEffects.SlowEffect, typeof(SlowEffect)},
        {StatusEffects.DamageOverTimeEffect, typeof(DamageOverTimeEffect)}
    };
}

public class SlowEffect : StatusEffect {
    ElementalCreature elemental;
    Modifier modifier;
    void Start() {
        elemental = GetComponent<ElementalCreature>();
        modifier = new Modifier(origin.GetStat(StatType.EffectStrength));
        elemental.ApplyMultiplicativeModifier(StatType.MovementSpeed, modifier);
    }
    void OnDestroy() {
        elemental.RemoveMultiplicativeModifier(StatType.MovementSpeed, modifier);
    }
}

public class DamageOverTimeEffect : StatusEffect {
    Health health;
    void Start() {
        health = GetComponent<Health>();
    }
    override public void Update() {
        health.DealDamage((int)origin.GetStat(StatType.EffectStrength));
        base.Update();
    }
}
