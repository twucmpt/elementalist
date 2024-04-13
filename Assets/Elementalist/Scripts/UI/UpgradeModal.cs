public class UpgradeModal {
  public bool isOpen;
  public ModalControl upgradeModal;

  public void TriggerUpgrade() {
    upgradeModal.OpenModal();
  }
}