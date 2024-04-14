using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Resistance {
    public Resistance(DamageType damageType, float multiplier) {
        this.damageType = damageType;
        this.multiplier = multiplier;
    }
    public DamageType damageType;
    public float multiplier = 1;
}
public class Health : MonoBehaviour
{
    public List<Resistance> resistances;
    public int maxHealth;
    public float health;
    public int rewardAmount;
    public PlayerLeveling rewardee;
    public UnityEvent onDeath;
    public UnityEvent onTakeDamage;

    public UnityEvent onHeal;

    public void DealDamage(Tuple<float, DamageType> damageInfo) {
        float damage = damageInfo.Item1;
        foreach (Resistance resistance in resistances) {
            if (resistance.damageType == damageInfo.Item2) {
                damage *= resistance.multiplier;
            }
        }
        if (health <= 0) return;

        health -= damage;
        if (damage > 0) {
            if (health <= 0) {
                onDeath.Invoke();
                rewardee.AddExp(rewardAmount);
            }
            else if (health > 0) {
                onTakeDamage.Invoke();
            }
        }
        else {
            onHeal.Invoke();
        }
    }

    public void SetRewardee(PlayerLeveling rewardee) {
        this.rewardee = rewardee;
    }
}
