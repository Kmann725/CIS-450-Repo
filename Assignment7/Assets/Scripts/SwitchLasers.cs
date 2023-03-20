/*
 * Kyle Manning
 * SwitchLasers.cs
 * Assignment 7
 * Concrete command for switching active laser groups
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLasers : MonoBehaviour, Command
{
    LaserSwitcher laserSwitcher;

    Stack<int> switches;

    public SwitchLasers(LaserSwitcher laserSwitcher)
    {
        this.laserSwitcher = laserSwitcher;
        switches = new Stack<int>();
    }

    public void Execute()
    {
        switches.Push(laserSwitcher.activeSet);

        laserSwitcher.Switch();
    }

    public void Undo()
    {
        if (switches.Count != 0)
        {
            laserSwitcher.activeSet = switches.Pop() - 1;
            laserSwitcher.Switch();
        }
    }
}
