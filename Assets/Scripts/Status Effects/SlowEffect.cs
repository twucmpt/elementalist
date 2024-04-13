using System.Runtime;

public class SlowEffect : StatusEffect {
    ElementalCreature target;
    Modifier modifier;
    void Start() {
        target = transform.parent.GetComponent<ElementalCreature>();
        modifier = new Modifier(elementalStats.GetStat(StatType.EffectStrength));
        target.stats.ApplyMultiplicativeModifier(StatType.MovementSpeed, modifier);
    }
    void OnDestroy() {
        target.stats.RemoveMultiplicativeModifier(StatType.MovementSpeed, modifier);
    }
}
