using System.Collections.Generic;
using UnityEngine;

public class UpgradeModal : MonoBehaviour {
  public bool isOpen;
  public ModalControl upgradeModal;
  public GameObject upgradeDisplayTilePrefab;

  public void TriggerUpgrade(List<ElementalDisplayInfo> upgrades) {
    // open the modal
    upgradeModal = gameObject.GetComponent<ModalControl>();
    upgradeModal.OpenModal();

    // find modal content section
    GameObject upgradeContent = upgradeModal.transform.Find("Content").gameObject;
    List<GameObject> children = new List<GameObject>(upgradeContent.GetComponentsInChildren<GameObject>());

    // populate the modal with the upgrades
    for (int i = 0; i < upgrades.Count; i++) {
      GameObject upgradeTile = Object.Instantiate(upgradeDisplayTilePrefab);
      upgradeTile.transform.SetParent(children[i % children.Count].transform);
      upgradeTile.GetComponent<UpgradeDisplayTile>().SetDisplay(upgrades[i]);
    }
  }
}