using UnityEngine;

public class EnemyMovement : ElementalMovement
{
    public Transform target;
    public Vector3 overridePos = Vector3.zero;
    public bool useOverride = false;

    override public void Start() {
        target = GameManager.instance.player.transform;
        base.Start();
    }

    protected override void FixedUpdate() {
        Vector3 pos = useOverride ? overridePos : target.position;
        moveVal = (pos - transform.position).normalized;
        base.FixedUpdate();
    }
}
