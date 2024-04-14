using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerKeybinds : MonoBehaviour {
  public ModalControl upgradeModal;
  public GameObject menu;

  private PlayerInput input;
  void Start() {
    input = GetComponent<PlayerInput>();
  }
  public void OnOpenUpgradeModal() {
    upgradeModal.OpenModal();
  }
  public void OnOpenMenu() {
    menu.SetActive(true);
    Time.timeScale = 0;
    input.SwitchCurrentActionMap("Menus");
  }
  public void OnCloseMenu() {
    menu.SetActive(false);
    Time.timeScale = 1;
    input.SwitchCurrentActionMap("Gameplay");
  }
}