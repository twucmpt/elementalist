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
            health.DealDamage(elementalStats.GetStat(StatType.EffectStrength));
            currentCooldown = dotRate;
        }
        base.Update();
    }
}
