using UnityEngine.UI;
using UnityEngine;

public class StatusManager : MonoBehaviour {
  public Image HealthBar;
  public Image ExpBar;
  public Health playerHealth;
  public PlayerLeveling playerLeveling;

  void Update() {
    HealthBar.fillAmount = playerHealth.health / playerHealth.maxHealth;
    ExpBar.fillAmount = playerLeveling.PercentToNextLevel();
  }
}
