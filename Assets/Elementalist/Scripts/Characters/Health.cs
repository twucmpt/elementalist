using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public float health;
    public UnityEvent onDeath;
    public UnityEvent onTakeDamage;

    public void DealDamage(float damage) {
        if (health <= 0) return;

        health -= damage;
        if (health <= 0) {
            onDeath.Invoke();
        }
        else if (health > 0) {
            onTakeDamage.Invoke();
        }
    }
}
