using UnityEngine;

public class StraightMovement : Movement
{
    public Vector2 direction;

    protected override void FixedUpdate() {
        moveVal = direction.normalized;
        base.FixedUpdate();
    }
}
