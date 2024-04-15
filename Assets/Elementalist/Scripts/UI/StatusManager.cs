using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class StatusManager : MonoBehaviour {
  public Image HealthBar;
  public Image ExpBar;
  public TextMeshProUGUI LevelText;
  public TextMeshProUGUI ScoreText;
  public TextMeshProUGUI ClockText;
  public Health playerHealth;
  public PlayerLeveling playerLeveling;

  private float time = 0;

  void Update() {
    HealthBar.fillAmount = playerHealth.health / playerHealth.maxHealth;
    ExpBar.fillAmount = playerLeveling.PercentToNextLevel();
    ScoreText.text = "Score: " + playerLeveling.Score;
    time += Time.deltaTime;
    ClockText.text = TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
  }

  public void SetLevel() {
    LevelText.text = playerLeveling.Level.ToString();
  }
}
