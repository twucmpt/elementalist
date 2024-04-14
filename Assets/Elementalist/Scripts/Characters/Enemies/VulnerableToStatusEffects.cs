using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VulnerableToStatusEffects : MonoBehaviour
{
    public void ApplyStatusEffect(Stats stats, GameObject effectPrefab) {
        GameObject statusEffectObj = Instantiate(effectPrefab, transform);
        StatusEffect effect = statusEffectObj.GetComponent<StatusEffect>();
        effect.Init(stats);
    }
}
