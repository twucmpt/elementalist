using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    public int damage;
    public float cooldown;
    private float currentCooldown;

    void Update() {
        if (currentCooldown > 0) currentCooldown -= Time.deltaTime;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & currentCooldown <= 0) {
            collision.gameObject.SendMessage("DealDamage", damage);
            currentCooldown = cooldown;
        }
    }
}
