/*
 * Kyle Manning
 * RunningAwayState.cs
 * Assignment 9
 * Concrete state; performs the running action and can switch to idle state
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunningAwayState : TargetState
{
    public override void StartRunning()
    {
        Vector3 newPos = Random.insideUnitSphere * GetComponent<TargetBehavior>().moveDistance;

        newPos += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(newPos, out hit, GetComponent<TargetBehavior>().moveDistance, 1);
        newPos = hit.position;

        agent.SetDestination(newPos);
    }

    public override void StopRunning()
    {
        targetStateManager.currentState = targetStateManager.idleState;
    }

    public override void StartSearching()
    {
        throw new System.NotImplementedException();
    }

    public override void StopSearching()
    {
        throw new System.NotImplementedException();
    }
}
