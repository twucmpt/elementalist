using System;
using System.Collections.Generic;
using UnityEngine;

public class ExplodePoisonCloud : MonoBehaviour
{
    public float rangeMultiplier = 2;
    public GameObject explosion;
    public void DealDamage(Tuple<float, DamageType> damageInfo) {
        if (damageInfo.Item2 == DamageType.Fire) {
            GameObject explosionObj = Instantiate(explosion, transform.position, Quaternion.identity);
            explosionObj.GetComponent<Projectile>().stats = new StaticStats(new Dictionary<StatType, float>(){
                [StatType.Damage] = damageInfo.Item1 + transform.parent.GetComponent<PoisonCloud>().stats.GetStat(StatType.Damage),
                [StatType.Range] = transform.parent.GetComponent<PoisonCloud>().stats.GetStat(StatType.Range) * rangeMultiplier,
                [StatType.EffectCooldown] = transform.parent.GetComponent<PoisonCloud>().stats.GetStat(StatType.EffectCooldown),
                [StatType.EffectStrength] = transform.parent.GetComponent<PoisonCloud>().stats.GetStat(StatType.EffectStrength)
            });
            Destroy(transform.parent.gameObject);
        }
    }
}
