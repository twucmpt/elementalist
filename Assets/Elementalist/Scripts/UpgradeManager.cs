// all the summons you can find

using System;
using System.Collections.Generic;
using UnityEngine;
public enum ElementalType { 
    Fire,
    Ice, 
    //Water, // unimplemented
    Earth,
    Air,
    //Light, // unimplemented
    //Dark // unimplemented
} 

// information about an elemental to be shown in UI
public class ElementalDisplayInfo {
    public ElementalType type;
    public int maxLevel;
    public string description;
    public string name;
    public Sprite icon;
}

// associate prefabs with ElementalTypes so we can pass prefabs to the SummonElementals script
[Serializable]
public class CodexEntry {
    public ElementalType type;

    public GameObject prefab;

    // elemental display info - destructured to work in unity editor
    public int maxLevel;
    public string description;
    public string name;
    public Sprite icon;
}

public class UpgradeManager : MonoBehaviour {

    // define in editor
    public List<CodexEntry> Codex;

    public SummonElementals player;
    public UpgradeModal modal;

    // update as player levels up
    public Dictionary<ElementalType, int> CurrentElementals = new Dictionary<ElementalType, int> {};

    //public void Awake() {
    //    TriggerUpgrade();
    //}

    public List<ElementalDisplayInfo> GenerateUpgrades() {
        Debug.Log("Generating upgrades");
        return Codex
        .FindAll(entry => !CurrentElementals.ContainsKey(entry.type) || CurrentElementals[entry.type] != entry.maxLevel)
        .ConvertAll(entry => new ElementalDisplayInfo {
            type = entry.type,
            maxLevel = entry.maxLevel,
            description = entry.description,
            name = entry.name,
            icon = entry.icon
        });
    }

    public void UpsertElemental(ElementalType type) {
        if(!CurrentElementals.ContainsKey(type)) {
            CurrentElementals[type] = 0;
        }
        CurrentElementals[type] += 1;
        player.UpsertElemental(Codex.Find(entry => entry.type == type).prefab);
    }

    public void TriggerUpgrade() {
        modal.TriggerUpgrade(GenerateUpgrades());
    }
}