using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatusEffectApplier : MonoBehaviour {
    public StatusEffects statusEffect;
    public void ApplyStatusEffect(ElementalCreature origin, Collider2D[] colliders) {
        foreach (Collider2D collider in colliders) {
            if (collider.gameObject.CompareTag("Enemy")) {
                StatusEffect effect = (StatusEffect)collider.gameObject.AddComponent(StatusEffect.effectsMap[statusEffect]);
                effect.origin = origin;
                effect.cooldown = origin.GetStat(StatType.EffectCooldown);
            }
        }
    }
}