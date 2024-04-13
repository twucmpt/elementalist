using UnityEngine;

public class NearestEnemyMovement : ElementalMovement
{
    public Transform target;

    protected override void FixedUpdate()
    {
        target = FindClosestEnemy();
        moveVal = (target.position - transform.position).normalized;
        base.FixedUpdate();
    }

    public Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = enemy.transform;
                distance = curDistance;
            }
        }
        return closest;
    }
}
