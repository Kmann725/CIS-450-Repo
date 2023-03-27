using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingEnemy : Enemy
{
    public Vector3 currentWaypoint;

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    public override void Movement()
    {
        if (!atPoint && !chasingPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, currentWaypoint) < 0.15f)
        {
            atPoint = true;

            GenerateNextPoint();
        }
    }

    private void GenerateNextPoint()
    {
        float xPos = Random.Range(xMin, xMax);
        float zPos = Random.Range(zMin, zMax);

        currentWaypoint = new Vector3(xPos, 1.7f, zPos);
    }
}
