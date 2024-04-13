using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public Animator animator;

    public UnityEvent onDeath;
    public UnityEvent onTakeDamage;

    public void DealDamage(int damage) {
        health -= damage;
        if (health <= 0 && health + damage > 0) {
            onDeath.Invoke();
        }
        else if (health > 0) {
            onTakeDamage.Invoke();
        }
    }
}
