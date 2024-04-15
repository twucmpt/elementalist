using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class UpgradeModal : ModalControl {
  //self reference, this is okay i guess
  public ModalControl upgradeModal;
  public UnityEvent<ElementalType> upsertElemental;

  public TextMeshProUGUI tooltip;

  private ElementalType selection = ElementalType.None;
  private Dictionary<ElementalType, UpgradeDisplayTile> tiles = new Dictionary<ElementalType, UpgradeDisplayTile>();

  private readonly static ElementalDisplayInfo blankTemplate = new ElementalDisplayInfo {
      type = ElementalType.None,
      maxLevel = 1,
      description = "",
      name = "",
      icon = null
  };

  public void TriggerUpgrade(List<ElementalDisplayInfo> upgrades) {
    tiles.Clear();

    // open self
    upgradeModal.OpenModal();

    // find modal content section
    GameObject upgradeContent = upgradeModal.transform.Find("ModalBlur/container/UpgradeModalFrame/Content/Content").gameObject;
    List<GameObject> children = new List<GameObject>{
      upgradeContent.transform.Find("Row 1/UpgradeUITile1").gameObject, 
      upgradeContent.transform.Find("Row 1/UpgradeUITile2").gameObject, 
      upgradeContent.transform.Find("Row 2/UpgradeUITile3").gameObject, 
      upgradeContent.transform.Find("Row 2/UpgradeUITile4").gameObject, 
    };

    // populate the modal with the upgrades
    for (int i = 0; i < children.Count; i++) {
      // select tile
      UpgradeDisplayTile newTile = children[i].GetComponent<UpgradeDisplayTile>();

      // set the display info
      ElementalDisplayInfo info = upgrades.Count > i ? upgrades[i] : blankTemplate;
      newTile.SetDisplay(info);
      newTile.HideCard();

      // store tile status
      if(info.type != ElementalType.None)
        tiles.Add(info.type, newTile);
    }

    if(tiles.Count < 4) {
      tooltip.text = "Max out elementals to unlock more combinations";
    }
  }

  public void SelectUpgrade(ElementalType type) {
    selection = type;
    tiles[type].ShowCard();
    foreach (ElementalType t in tiles.Keys) {
      if (t != type) {
        tiles[t].HideCard();
      }
    }
  }

  public void ConfirmUpgrade() {
    if (selection != ElementalType.None) {
      // upgrade the player
      upsertElemental.Invoke(selection);

      // close the modal
      CloseModal();

      selection = ElementalType.None;
    }
  }
}