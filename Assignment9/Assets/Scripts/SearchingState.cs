/*
 * Kyle Manning
 * SearchingState.cs
 * Assignment 9
 * Concrete state; performs the searching action and can switch to idle or running state
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchingState : TargetState
{
    public override void StartRunning()
    {
        targetStateManager.currentState = targetStateManager.runningAwayState;

        targetStateManager.StartRunning();
    }

    public override void StopRunning()
    {
        throw new System.NotImplementedException();
    }

    public override void StartSearching()
    {
        transform.Rotate(0, 120 * Time.deltaTime, 0);
    }

    public override void StopSearching()
    {
        targetStateManager.currentState = targetStateManager.idleState;
    }
}
