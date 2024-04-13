using UnityEngine;

public class PlayerKeybinds : MonoBehaviour {
  public ModalControl upgradeModal;

  public void OnOpenUpgradeModal() {
    upgradeModal.OpenModal();
  }
}