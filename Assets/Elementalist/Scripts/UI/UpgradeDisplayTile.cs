using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeDisplayTile : UIButton {
  public ElementalType type;

  public UpgradeModal modal;
  public Image currentLevelBar;
  public Image nextLevelBar;

  public Image comboImage1;
  public Image comboImage2;

  private float nextLevelFillAmount;

  public void SetDisplay(ElementalDisplayInfo info) {
    type = info.type;

    // set the display info

    GameObject name = gameObject.transform.Find("Name").gameObject;
    GameObject description = gameObject.transform.Find("Description").gameObject;
    GameObject icon = gameObject.transform.Find("Icon").gameObject;

    name.GetComponentInChildren<TextMeshProUGUI>().text = info.name;
    description.GetComponentInChildren<TextMeshProUGUI>().text = info.description;
    icon.GetComponentInChildren<Image>().sprite = info.icon;
    if(info.combinationIcons.Count > 0) {
      comboImage1.sprite = info.combinationIcons[0];
      comboImage2.sprite = info.combinationIcons[1];
    }
    else {
      comboImage1.gameObject.SetActive(false);
      comboImage2.gameObject.SetActive(false);
    }

    currentLevelBar.fillAmount = (float)info.currentLevel / info.maxLevel;
    nextLevelFillAmount = nextLevelBar.fillAmount = (float)(info.currentLevel + 1) / info.maxLevel;
  }

  public void ShowCard() {
    // highlight the tile
    gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
    currentLevelBar.transform.parent.gameObject.SetActive(true);
    nextLevelBar.transform.parent.gameObject.SetActive(true);
    StartCoroutine(BlinkRoutine());
  }

  public void HideCard() {
    // unhighlight the tile
    gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f);
    currentLevelBar.transform.parent.gameObject.SetActive(false);
    nextLevelBar.transform.parent.gameObject.SetActive(false);
    StopCoroutine(BlinkRoutine());
  }

  public override void OnPointerClick(UnityEngine.EventSystems.PointerEventData _eventData) {
    if(type != ElementalType.None)
      modal.SelectUpgrade(type);
  }

  private IEnumerator BlinkRoutine() {
    while(true){
      yield return new WaitForSecondsRealtime(0.7f);
      if(nextLevelBar.fillAmount > 0)
        nextLevelBar.fillAmount = 0;
      else
        nextLevelBar.fillAmount = nextLevelFillAmount;
    }
  }
}