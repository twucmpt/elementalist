using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
  public PlayerLeveling playerLeveling;
  public TextMeshProUGUI ScoreText;

  void Update() {
    ScoreText.text = "Score: " + playerLeveling.Score;
  }
}
