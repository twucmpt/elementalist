public class WetEffect : StatusEffect {
    void Start() {
        foreach(Resistance resistance in health.resistances) {
            if (resistance.damageType == DamageType.Fire) {
                resistance.multiplier -= 0.5f;
            }
            else if (resistance.damageType == DamageType.Lightning) {
                resistance.multiplier += 1f;
            }
        }
    }
    void OnDestroy() {
        foreach(Resistance resistance in health.resistances) {
            if (resistance.damageType == DamageType.Fire) {
                resistance.multiplier += 0.5f;
            }
            else if (resistance.damageType == DamageType.Lightning) {
                resistance.multiplier -= 1f;
            }
        }
    }
}
