using UnityEngine;

public class EnemyMovement : ElementalMovement
{
    public Transform target;

    override public void Start() {
        target = GameManager.instance.player.transform;
        base.Start();
    }

    protected override void FixedUpdate() {
        moveVal = (target.position - transform.position).normalized;
        base.FixedUpdate();
    }
}
