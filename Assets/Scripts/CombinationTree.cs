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
public class CombinationTree
{

  public ElementalCombination[] combinations = new ElementalCombination[]
  {
    new ElementalCombination { type1 = ElementalType.Fire, type2 = ElementalType.Water, result = ElementalType.Air }, // EXAMPLE
  };

  public List<ElementalCombination> getPossibleCombinations(ElementalType[] types)
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
