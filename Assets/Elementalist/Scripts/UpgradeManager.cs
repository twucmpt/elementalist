// all the summons you can find

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ElementalType { 
    Fire,
    Ice, 
    Water,
    Earth,
    Air,
    Lightning,
    Nature,
    Blood,
    Sand,
    Magma,
    None
} 

// information about an elemental to be shown in UI
public class ElementalDisplayInfo {

    public ElementalType type;
    public int maxLevel;
    public string description;
    public string name;
    public Sprite icon;
    public bool isCombination = false;

    public int currentLevel;

    public List<Sprite> combinationIcons;
}

// associate prefabs with ElementalTypes so we can pass prefabs to the SummonElementals script
[Serializable]
public class CodexEntry {
    public ElementalType type;

    public GameObject prefab {get {
        return GameManager.instance.GetDifficultySetting().elementals.Find(e => e.GetComponent<ElementalCreature>().elementalType == type);
    }}

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

    public List<ElementalDisplayInfo> GenerateUpgrades() {
        
        List<ElementalDisplayInfo> validElements = Codex
            .FindAll(entry => !CurrentElementals.ContainsKey(entry.type) || CurrentElementals[entry.type] != entry.maxLevel) // filter out maxed out elementals
            .FindAll(entry => !CombinationTree.IsCombination(entry.type) || CurrentElementals.ContainsKey(entry.type) || CanCombine(entry.type)) // filter out combination elementals that can't be upgraded
            .ConvertAll(entry => {
                ElementalDisplayInfo edi = new ElementalDisplayInfo {
                    type = entry.type,
                    maxLevel = entry.maxLevel,
                    description = entry.description,
                    name = entry.name,
                    icon = entry.icon,
                    currentLevel = CurrentElementals.ContainsKey(entry.type) ? CurrentElementals[entry.type] : 0,
                    combinationIcons = new List<Sprite>()
                };
                if(CombinationTree.IsCombination(entry.type)) {
                    edi.combinationIcons.Add(Codex.Find(e => e.type == CombinationTree.GetIngredients(entry.type).Item1).icon);
                    edi.combinationIcons.Add(Codex.Find(e => e.type == CombinationTree.GetIngredients(entry.type).Item2).icon);
                }
                return edi;
            });

        validElements.Shuffle();

        return validElements.Take(4).ToList();
    }

    public void UpsertElemental(ElementalType type) {
        CodexEntry entry = Codex.Find(entry => entry.type == type);

        if(!CurrentElementals.ContainsKey(type)) {
            CurrentElementals[type] = 0;
        }
        CurrentElementals[type] += 1;
        player.UpsertElemental(entry.prefab);

        if(CombinationTree.IsCombination(type)) {
            Tuple<ElementalType, ElementalType> ingredients = CombinationTree.GetIngredients(type);
            player.ResetElemental(Codex.Find(entry => entry.type == ingredients.Item1).prefab);
            player.ResetElemental(Codex.Find(entry => entry.type == ingredients.Item2).prefab);
            CurrentElementals[ingredients.Item1] = 0;
            CurrentElementals[ingredients.Item2] = 0;
        }
    }

    public void TriggerUpgrade() {
        modal.TriggerUpgrade(GenerateUpgrades());
    }

    private bool CanCombine(ElementalType type) {        
        List<ElementalType> maxxedOutElementals = Codex
            .FindAll(entry => CurrentElementals.ContainsKey(entry.type) && CurrentElementals[entry.type] == entry.maxLevel)
            .ConvertAll(entry => entry.type);

        List<ElementalCombination> possibleCombinations = CombinationTree.GetPossibleCombinations(maxxedOutElementals.ToArray());

        return possibleCombinations.Exists(combination => combination.result == type);
    }
}