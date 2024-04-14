using UnityEngine;

public class StatusEffectApplier : MonoBehaviour {
    public GameObject statusEffect;
    public void ApplyStatusEffectColliders(ElementalCreature origin, Collider2D[] colliders) {
        foreach (Collider2D collider in colliders) {
            if (collider.gameObject.CompareTag("Enemy")) {
                ApplyStatusEffectToTarget(origin, collider.gameObject);
            }
        }
    }

    public void ApplyStatusEffectToTarget(ElementalCreature origin, GameObject target) {
        GameObject statusEffectObj = Instantiate(statusEffect, target.transform);
        StatusEffect effect = statusEffectObj.GetComponent<StatusEffect>();
        effect.Init(origin.stats);
    }
}