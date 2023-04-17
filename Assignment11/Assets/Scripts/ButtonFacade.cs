/*
 * Kyle Manning
 * ButtonFacade.cs
 * Assignment 11
 * Facade for the facade pattern; calls methods in subclasses to handle behaviors
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFacade : MonoBehaviour
{
    private SpawnBall spawner;
    private BarrierSwitch switcher;
    public BallJump jumper;

    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<SpawnBall>();
        switcher = GameObject.FindGameObjectWithTag("switcher").GetComponent<BarrierSwitch>();
    }

    public void SpawnSphere()
    {
        spawner.SpawnSphere();
        jumper = spawner.ReturnJumper();
    }

    public void SphereJump()
    {
        jumper.Jump();
    }

    public void SwitchBarriers()
    {
        switcher.SwitchBarriers();
    }
}
