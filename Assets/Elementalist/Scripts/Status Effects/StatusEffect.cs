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

    public void Init(Stats stats) {
        elementalStats = stats;
        cooldown = stats.GetStat(StatType.EffectCooldown);
    }
}