using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HelpTip {
  public Sprite image;
  public string text;
}

public class HelpModal : ModalControl
{
  public HelpTip[] tips;
  public TextMeshProUGUI tipText;
  public Image tipImage;

  private int currentTipIndex = 0;

  void Start() {
    ShowTip(0);
  }

  void Update() {
    if(Input.GetKeyDown(KeyCode.Escape))
    {
        CloseModal();
    }
  }


  public void NextTip() {
    ShowTip(currentTipIndex + 1);
  }

  public void PreviousTip() {
    ShowTip(currentTipIndex - 1);
  }

  public void ShowTip(int index) {

    int i = (index + tips.Length) % tips.Length;

    tipText.text = tips[i].text;
    tipImage.sprite = tips[i].image;

    currentTipIndex = i;
  }
}