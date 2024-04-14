using UnityEngine;
using UnityEngine.Events;

public class Explosion : Projectile
{
    public DamageType damageType;
    int count = 2;
    void FixedUpdate() {
        count -= 1;
        if (count == 0) Destroy(this);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        collider.gameObject.SendMessage("DealDamage", (stats.GetStat(StatType.Damage), damageType));
    }
}
