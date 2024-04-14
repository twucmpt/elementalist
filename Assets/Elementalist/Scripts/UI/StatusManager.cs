using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class StatusManager : MonoBehaviour {
  public Image HealthBar;
  public Image ExpBar;
  public TextMeshProUGUI LevelText;
  public Health playerHealth;
  public PlayerLeveling playerLeveling;

  void Update() {
    HealthBar.fillAmount = playerHealth.health / playerHealth.maxHealth;
    ExpBar.fillAmount = playerLeveling.PercentToNextLevel();
  }

  public void SetLevel() {
    Debug.Log("Setting level text to " + playerLeveling.Level.ToString() + ".");
    LevelText.text = playerLeveling.Level.ToString();
  }
}
