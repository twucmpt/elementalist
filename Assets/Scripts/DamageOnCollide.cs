using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    public int damage;
    void OnCollisionStay2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("DealDamage", damage);
    }
}
