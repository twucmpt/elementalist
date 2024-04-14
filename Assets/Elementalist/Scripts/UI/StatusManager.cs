using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class StatusManager : MonoBehaviour {
  public Image HealthBar;
  public Image ExpBar;
  public TextMeshProUGUI LevelText;
  public TextMeshProUGUI ScoreText;
  public Health playerHealth;
  public PlayerLeveling playerLeveling;

  void Update() {
    HealthBar.fillAmount = playerHealth.health / playerHealth.maxHealth;
    ExpBar.fillAmount = playerLeveling.PercentToNextLevel();
    ScoreText.text = "Score: " + playerLeveling.GetScore();
  }

  public void SetLevel() {
    LevelText.text = playerLeveling.Level.ToString();
  }
}
