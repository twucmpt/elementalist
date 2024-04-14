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
  };

  public static List<ElementalCombination> getPossibleCombinations(ElementalType[] types)
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
}
