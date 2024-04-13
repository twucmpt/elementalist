// #publicgang

public enum ElementalType { 
    Fire, // unimplemented
    Water, // unimplemented
    Earth, // unimplemented
    Air, // unimplemented
    Light, // unimplemented
    Dark // unimplemented
} 
public struct Elemental {
    ElementalType type;
    int level;
}

public interface Leveling {
    int exp { get; set; }

    // level should be calculated based on exp
    int level { get; }

    void AddExp(int exp);

    // the list of elementals the player has unlocked
    Elemental[] elementals { get; set; }

    void AddElemental(ElementalType type);
    void UpgradeElemental(ElementalType type);

    // returns true if the elementals were combined successfully
    bool TryCombineElementals(ElementalType type1, ElementalType type2);
}