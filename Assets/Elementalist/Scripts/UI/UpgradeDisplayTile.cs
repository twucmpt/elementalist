using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeDisplayTile : UIButton {
  public ElementalType type;
  public UnityEvent<ElementalType> tileClicked;

  public void SetDisplay(ElementalDisplayInfo info) {
    type = info.type;

    // set the display info

    GameObject name = gameObject.transform.Find("Name").gameObject;
    GameObject description = gameObject.transform.Find("Description").gameObject;
    GameObject icon = gameObject.transform.Find("Icon").gameObject;

    name.GetComponentInChildren<TextMeshProUGUI>().text = info.name;
    description.GetComponentInChildren<TextMeshProUGUI>().text = info.description;
    icon.GetComponentInChildren<Image>().sprite = info.icon;
  }

  public void Highlight() {
    // highlight the tile
    gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
  }

  public void Unhighlight() {
    // unhighlight the tile
    gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f);
  }
}