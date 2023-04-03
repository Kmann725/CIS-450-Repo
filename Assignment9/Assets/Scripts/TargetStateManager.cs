/*
 * Kyle Manning
 * TargetStateManager.cs
 * Assignment 9
 * Manager which initializes the target's states and sets the current state
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetStateManager : MonoBehaviour
{
    public TargetState idleState { get; set; }
    public TargetState searchingState { get; set; }
    public TargetState runningAwayState { get; set; }

    public TargetState currentState { get; set; }

    private void Start()
    {
        idleState = gameObject.AddComponent<IdleState>();
        searchingState = gameObject.AddComponent<SearchingState>();
        runningAwayState = gameObject.AddComponent<RunningAwayState>();

        currentState = idleState;
    }

    public void StartSearching()
    {
        currentState.StartSearching();
    }

    public void StopSearching()
    {
        currentState.StopSearching();
    }

    public void StartRunning()
    {
        currentState.StartRunning();
    }

    public void StopRunning()
    {
        currentState.StopRunning();
    }
}
