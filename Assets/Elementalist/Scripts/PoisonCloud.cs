using System.Collections.Generic;
using UnityEngine;

public class PoisonCloud : Projectile
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
            collider.gameObject.SendMessage("DealDamage", (stats.GetStat(StatType.Damage), DamageType.Poison));
        }
    }
}
