using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// List of combinations at the bottom of the file ;)

[System.Serializable]
public class ElementalCombination
{
  public ElementalType type1;
  public ElementalType type2;
  public ElementalType result;
}

[CreateAssetMenu(fileName = "CombinationTree", menuName = "CombinationTree"), System.Serializable]
public static class CombinationTree
{

  public static ElementalCombination[] combinations = new ElementalCombination[]
  {
    new ElementalCombination { type1 = ElementalType.Water, type2 = ElementalType.Earth, result = ElementalType.Nature },
    new ElementalCombination { type1 = ElementalType.Water, type2 = ElementalType.Air, result = ElementalType.Ice },
    new ElementalCombination { type1 = ElementalType.Water, type2 = ElementalType.Fire, result = ElementalType.Blood },
    new ElementalCombination { type1 = ElementalType.Air, type2 = ElementalType.Fire, result = ElementalType.Lightning },
    new ElementalCombination { type1 = ElementalType.Air, type2 = ElementalType.Earth, result = ElementalType.Sand },
    new ElementalCombination { type1 = ElementalType.Fire, type2 = ElementalType.Earth, result = ElementalType.Magma },
  };

  public static List<ElementalCombination> GetPossibleCombinations(ElementalType[] types)
  {
    List<ElementalCombination> possibleCombinations = new List<ElementalCombination>();
    foreach (ElementalCombination combination in combinations)
    {
      if (types.Contains(combination.type1) && types.Contains(combination.type2))
      {
        possibleCombinations.Add(combination);
      }
    }
    return possibleCombinations;
  }

  public static Tuple<ElementalType, ElementalType> GetIngredients(ElementalType type)
  {
    if (!IsCombination(type))
    {
      return null;
    }
    return new Tuple<ElementalType, ElementalType>(combinations.First(c => c.result == type).type1, combinations.First(c => c.result == type).type2);
  }

  public static bool IsCombination(ElementalType type)
  {
    return combinations.Any(c => c.result == type);
  }
}
