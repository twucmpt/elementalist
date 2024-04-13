using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public void DealDamage(int damage) {
        health -= damage;
    }
}
