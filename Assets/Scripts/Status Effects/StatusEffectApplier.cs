using UnityEngine;

public class StatusEffectApplier : MonoBehaviour {
    public GameObject statusEffect;
    public void ApplyStatusEffectColliders(ElementalCreature origin, Collider2D[] colliders) {
        foreach (Collider2D collider in colliders) {
            if (collider.gameObject.CompareTag("Enemy")) {
                ApplyStatusEffect(origin, collider.gameObject);
            }
        }
    }

    public void ApplyStatusEffect(ElementalCreature origin, GameObject target) {
        Debug.Log($"Applying status effect {statusEffect.name} to {target.name}.");
        GameObject statusEffectObj = Instantiate(statusEffect, target.transform);
        StatusEffect effect = statusEffectObj.GetComponent<StatusEffect>();
        effect.Init(origin);
    }
}