using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : Enemy
{
    public Vector3[] patrolRoute;
    public int nextRoutePoint = 1;
    public int lastRoutePoint = 2;

    public override void Movement()
    {
        if (!atPoint && !chasingPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolRoute[nextRoutePoint], speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, patrolRoute[nextRoutePoint]) < 0.15f)
        {
            atPoint = true;

            if (nextRoutePoint == lastRoutePoint)
            {
                nextRoutePoint = 0;
            }
            else
            {
                nextRoutePoint++;
            }
        }
    }
}
