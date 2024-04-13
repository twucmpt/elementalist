using UnityEngine;

public class EnemyMovement : Movement
{
    public Transform target;

    protected override void FixedUpdate() {
        moveVal = (target.position - transform.position).normalized;
        base.FixedUpdate();
    }
}
