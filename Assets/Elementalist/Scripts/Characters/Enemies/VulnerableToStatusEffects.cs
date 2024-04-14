using System;
using UnityEngine;

public class VulnerableToStatusEffects : MonoBehaviour
{
    public void ApplyStatusEffect(Tuple<Stats,GameObject> appInfo) {
        Stats stats = appInfo.Item1;
        GameObject effectPrefab = appInfo.Item2;
        GameObject statusEffectObj = Instantiate(effectPrefab, transform);
        StatusEffect effect = statusEffectObj.GetComponent<StatusEffect>();
        effect.Init(stats);
    }
}
