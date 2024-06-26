using UnityEngine;
using UnityEngine.Events;

public class ExplodeOnCollide : MonoBehaviour
{
    public UnityEvent OnExplode;
    private ElementalCreature elemental;

    void Start() {
        elemental = GetComponent<ElementalCreature>();
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            // Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, elemental.stats.GetStat(StatType.Range));

            // foreach (Collider2D collider in colliders) {
            //     if (collider.gameObject.CompareTag("Enemy")) {
            //         collider.gameObject.SendMessage("DealDamage", elemental.stats.GetStat(StatType.Damage));
            //     }
            // }
            OnExplode.Invoke();
            Destroy(gameObject);
        }
    }
   
}
