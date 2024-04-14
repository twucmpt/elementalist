using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public float health;
    public int rewardAmount;
    public PlayerLeveling rewardee;
    public UnityEvent onDeath;
    public UnityEvent onTakeDamage;

    public UnityEvent onHeal;

    public void DealDamage(float damage) {
        if (health <= 0) return;

        health -= damage;
        if (damage > 0) {
            if (health <= 0) {
                onDeath.Invoke();
                rewardee.AddExp(rewardAmount);
            }
            else if (health > 0) {
                onTakeDamage.Invoke();
            }
        }
        else {
            onHeal.Invoke();
        }
    }

    public void SetRewardee(PlayerLeveling rewardee) {
        this.rewardee = rewardee;
    }
}
