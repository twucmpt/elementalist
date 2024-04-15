using System;
using UnityEngine;

public class SandProjectile : Projectile
{
    public Vector3 direction;

    void Start() {
        Transform target = FindClosestEnemy();
        direction = (target.position - transform.position).normalized;
    }

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
            collider.gameObject.SendMessage("DealDamage", new Tuple<float,DamageType>(stats.GetStat(StatType.Damage), DamageType.Sand));
        }
    }

    void FixedUpdate() {
        transform.position += direction * stats.GetStat(StatType.EffectStrength) * Time.fixedDeltaTime;
    }

    public Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = enemy.transform;
                distance = curDistance;
            }
        }
        return closest;
    }
}
