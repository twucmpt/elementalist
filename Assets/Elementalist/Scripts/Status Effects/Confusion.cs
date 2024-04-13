using System.Runtime;
using UnityEngine;

public class Confusion : StatusEffect {
    EnemyMovement movement;
    private float changeTarget = 0;
    void Start() {
        movement = transform.parent.GetComponent<EnemyMovement>();
        movement.useOverride = true;
    }
    override public void Update() {
        changeTarget -= Time.deltaTime;
        if (changeTarget <= 0) {
            movement.overridePos = ChangeTarget();
            changeTarget = 1f;
        }
        base.Update();
    }
    Vector3 ChangeTarget() {
        return transform.position + new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),0f)*100f;
    }
    void OnDestroy() {
        movement.useOverride = false;
    }
}
