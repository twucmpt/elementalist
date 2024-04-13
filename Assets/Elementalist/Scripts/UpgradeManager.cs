// all the summons you can find

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ElementalType { 
    Fire,
    Ice, 
    //Water, // unimplemented
    //Earth, // unimplemented
    //Air, // unimplemented
    //Light, // unimplemented
    //Dark // unimplemented
} 

// information about an elemental to be shown in UI
public struct ElementalDisplayInfo {
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

    public ElementalDisplayInfo displayInfo;
}

public class UpgradeManager : MonoBehaviour {

    // define in editor
    public static List<CodexEntry> Codex;

    // update as player levels up
    public Dictionary<ElementalType, int> CurrentElementals;

    public List<ElementalDisplayInfo> GenerateUpgrades() {
        return Codex
        .FindAll(entry => CurrentElementals[entry.type] < entry.displayInfo.maxLevel)
        .ConvertAll(entry => entry.displayInfo);
    }
}