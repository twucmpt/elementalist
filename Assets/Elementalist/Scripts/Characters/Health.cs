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
    public float invicinbilityCooldown;
    public float invincibility = 0;
    public List<Resistance> resistances;
    public float maxHealth;
    public float health;
    public int rewardAmount;
    public PlayerLeveling rewardee;
    public UnityEvent onDeath;
    public UnityEvent onTakeDamage;

    public UnityEvent onHeal;

    public void DealDamage(Tuple<float, DamageType> damageInfo) {
        if (health <= 0 | invincibility > 0) return;
        if (gameObject.tag == "Player" && damageInfo.Item2 != DamageType.Untyped) return;

        float damage = damageInfo.Item1;
        foreach (Resistance resistance in resistances) {
            if (resistance.damageType == damageInfo.Item2) {
                damage *= resistance.multiplier;
            }
        }

        health -= damage;
        if (damage > 0) {
            if (health <= 0) {
                onDeath.Invoke();
            }
            else if (health > 0) {
                onTakeDamage.Invoke();
                invincibility = invicinbilityCooldown;
            }
        }
        else {
            onHeal.Invoke();
        }
    }

    public void SetRewardee(PlayerLeveling rewardee) {
        this.rewardee = rewardee;
    }

    public void SetHealth(float val) {
        health = Math.Min(val, maxHealth);
    }

    public void ResetHealthToMax() {
        SetHealth(maxHealth);
    }

    void Update() {
        if (invincibility > 0) invincibility -= Time.deltaTime;
    }
}
