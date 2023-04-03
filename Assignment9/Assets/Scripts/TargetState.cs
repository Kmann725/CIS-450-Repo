/*
 * Kyle Manning
 * TargetState.cs
 * Assignment 9
 * Abstract class for target states
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class TargetState : MonoBehaviour
{
    protected TargetStateManager targetStateManager;
    protected NavMeshAgent agent;

    public void Start()
    {
        this.targetStateManager = GetComponent<TargetStateManager>();
        this.agent = GetComponent<NavMeshAgent>();
    }

    public abstract void StartSearching();

    public abstract void StopSearching();

    public abstract void StartRunning();

    public abstract void StopRunning();
}
