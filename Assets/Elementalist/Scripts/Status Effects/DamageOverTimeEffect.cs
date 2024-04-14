using System;
using UnityEngine;

public class DamageOverTimeEffect : StatusEffect {
    public float dotRate = 1f;
    private float currentCooldown;
    void Start() {
        currentCooldown = dotRate;
    }
    override public void Update() {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <=0 ) {
            for (int i = 0; i < health.transform.childCount; i++) {
                if (health.transform.GetChild(i).GetComponent<WetEffect>() != null) {
                    Destroy(health.transform.GetChild(i));
                    Destroy(gameObject);
                }
            }
            health.DealDamage(new Tuple<float, DamageType>(elementalStats.GetStat(StatType.EffectStrength), DamageType.Fire));
            currentCooldown = dotRate;
        }
        base.Update();
    }
}
