/*
 * Kyle Manning
 * IdleState.cs
 * Assignment 9
 * Concrete state; can switch to the searching state
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : TargetState
{
    public override void StartRunning()
    {
        throw new System.NotImplementedException();
    }

    public override void StopRunning()
    {
        throw new System.NotImplementedException();
    }

    public override void StartSearching()
    {
        targetStateManager.currentState = targetStateManager.searchingState;
    }

    public override void StopSearching()
    {
        throw new System.NotImplementedException();
    }
}
