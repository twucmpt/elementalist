using UnityEngine;


public class StatusEffect : MonoBehaviour
{
    protected Stats elementalStats;
    public float cooldown = float.PositiveInfinity;
    protected Health health;
    void Awake() {
        health = transform.parent.GetComponent<Health>();
    }
    public virtual void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0 || health.health <= 0) Destroy(gameObject);
    }

    public void Init(ElementalCreature origin) {
        elementalStats = origin.stats;
        cooldown = origin.stats.GetStat(StatType.EffectCooldown);
    }
}