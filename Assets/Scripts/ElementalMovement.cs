using UnityEngine;

public class ElementalMovement : Movement
{
    ElementalCreature elemental;
    public override void Start() {
        elemental = GetComponent<ElementalCreature>();
        base.Start();
    }
    override public float GetMoveSpeed() {
        return elemental.GetStat(StatType.MovementSpeed);
    }
}
