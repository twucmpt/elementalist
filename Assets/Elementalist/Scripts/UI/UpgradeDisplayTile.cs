using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDisplayTile : MonoBehaviour {
  public void SetDisplay(ElementalDisplayInfo info) {
    // set the display info
    List<GameObject> children = new List<GameObject>(gameObject.GetComponentsInChildren<GameObject>());

    GameObject name = children.Find(child => child.name == "Name");
    GameObject description = children.Find(child => child.name == "Description");
    GameObject icon = children.Find(child => child.name == "Icon");

    name.GetComponentInChildren<TextMeshProUGUI>().text = info.name;
    description.GetComponentInChildren<TextMeshProUGUI>().text = info.description;
    icon.GetComponentInChildren<Image>().sprite = info.icon;
  }
}