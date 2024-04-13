using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageOnCollide : MonoBehaviour
{
    public int damage;
    public float cooldown;
    private float currentCooldown;

    public UnityEvent onAttack1;
    public UnityEvent onAttack2;

    void Update() {
        if (currentCooldown > 0) currentCooldown -= Time.deltaTime;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & currentCooldown <= 0) {
            collision.gameObject.SendMessage("DealDamage", damage);
            currentCooldown = cooldown;
            if(Random.Range(0, 10) < 2)
                onAttack2.Invoke();
            else
                onAttack1.Invoke();
        }
    }
}
