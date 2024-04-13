public class DamageOverTimeEffect : StatusEffect {
    Health health;
    void Start() {
        health = transform.parent.GetComponent<Health>();
    }
    override public void Update() {
        health.DealDamage((int)elementalStats.GetStat(StatType.EffectStrength));
        base.Update();
    }
}
