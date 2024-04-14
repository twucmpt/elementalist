using System.Collections.Generic;
using UnityEngine;

public class LightningProjectile : Projectile
{
    public Transform target;
    public int count = 3;

    void Start() {
        target = FindClosestEnemy();
        count = (int)stats.GetStat(StatType.EffectStrength);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform == target) {
            collider.gameObject.SendMessage("DealDamage", stats.GetStat(StatType.Damage));
            target = FindClosestEnemy();
            count -= 1;
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.transform == target) {
            collider.gameObject.SendMessage("DealDamage", stats.GetStat(StatType.Damage));
            target = FindClosestEnemy();
        }
    }

    void FixedUpdate() {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, 10 * Time.fixedDeltaTime);
        transform.position = newPosition;
    }

    public Transform FindClosestEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, stats.GetStat(StatType.Range));
        List<Transform> enemies = new List<Transform>();
        foreach (Collider2D collider in colliders) {
            if (collider.gameObject.CompareTag("Enemy") & collider.transform != target) {
                enemies.Add(collider.transform);
            }
        }

        if (enemies.Count == 0 | count <= 0) {
            Destroy(gameObject);
        }

        int i = Random.Range(0, enemies.Count);
        return enemies[i];
    }
}
