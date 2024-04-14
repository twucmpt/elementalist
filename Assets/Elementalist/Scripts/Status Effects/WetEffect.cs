public class WetEffect : StatusEffect {
    private Resistance resistanceFire;
    private Resistance weaknessLightning;
    void Start() {
        resistanceFire = new Resistance(DamageType.Fire, 0.5f);
        weaknessLightning = new Resistance(DamageType.Lightning, 0.5f);
        health.resistances.Add(resistanceFire);
        health.resistances.Add(weaknessLightning);
    }
    void OnDestroy() {
        health.resistances.Remove(resistanceFire);
        health.resistances.Remove(weaknessLightning);
    }
}
