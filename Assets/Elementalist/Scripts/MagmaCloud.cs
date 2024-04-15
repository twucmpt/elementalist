using System;
using UnityEngine;

public class MagmaCloud : Projectile
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
        if (collider.gameObject.CompareTag("Enemy")) {
            collider.gameObject.SendMessage("DealDamage", new Tuple<float,DamageType>(stats.GetStat(StatType.Damage), DamageType.Magma));
        }
    }
}
