using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeModal : ModalControl {
  public bool isOpen;
  //self reference, this is okay i guess
  public ModalControl upgradeModal;
  public GameObject upgradeDisplayTilePrefab;

  private ElementalType selection;
  private Dictionary<ElementalType, UpgradeDisplayTile> tiles = new Dictionary<ElementalType, UpgradeDisplayTile>();

  public void TriggerUpgrade(List<ElementalDisplayInfo> upgrades) {
    // open self
    upgradeModal.OpenModal();

    // find modal content section
    GameObject upgradeContent = upgradeModal.transform.Find("ModalBlur/UpgradeModalFrame/Content").gameObject;
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
      newTile.SetDisplay(upgrades[i]);
      newTile.HideCard();

      // store tile status
      tiles.Add(upgrades[i].type, newTile);
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
}