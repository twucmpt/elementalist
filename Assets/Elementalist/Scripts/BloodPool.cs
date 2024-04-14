using System.Collections.Generic;
using UnityEngine;

public class BloodPool : Projectile
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        DoTriggerStuff(collider);
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        DoTriggerStuff(collider);
    }

    void DoTriggerStuff(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            collider.gameObject.SendMessage("DealDamage", -stats.GetStat(StatType.EffectStrength));
        }
    }
}
