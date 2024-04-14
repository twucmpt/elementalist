using System;
using UnityEngine;
using UnityEngine.Events;

public class Explosion : Projectile
{
    public DamageType damageType;
    public GameObject statusEffectPrefab;
    int count = 2;

    void Start() {
        transform.localScale = Vector3.one*stats.GetStat(StatType.Range);
    }
    void FixedUpdate() {
        count -= 1;
        if (count == 0) Destroy(this);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"Collided with {collider}");
        collider.gameObject.SendMessage("DealDamage", new Tuple<float,DamageType>(stats.GetStat(StatType.Damage), damageType));
        if (statusEffectPrefab != null) collider.gameObject.SendMessage("ApplyStatusEffect", new Tuple<Stats,GameObject>(stats, statusEffectPrefab));
    }
}
