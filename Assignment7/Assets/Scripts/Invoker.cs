/*
 * Kyle Manning
 * Invoker.cs
 * Assignment 7
 * Invoker which calls for command executions when certain buttons are pressed
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    public LaserSwitcher laserSwitcher;
    public PlatformMover platform1;
    public PlatformMover platform2;
    public PlatformMover platform3;
    private Command switchLasers;
    private Command movePlatformLeft;
    private Command movePlatformRight;

    public Stack<Command> commandHistory;

    // Start is called before the first frame update
    void Start()
    {
        switchLasers = new SwitchLasers(laserSwitcher);
        movePlatformLeft = new MovePlatformLeft(platform1, platform2, platform3);
        movePlatformRight = new MovePlatformRight(platform1, platform2, platform3);

        commandHistory = new Stack<Command>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switchLasers.Execute();
            commandHistory.Push(switchLasers);
        }

        if (Input.GetMouseButtonDown(0))
        {
            movePlatformLeft.Execute();
            commandHistory.Push(movePlatformLeft);
        }

        if (Input.GetMouseButtonDown(1))
        {
            movePlatformRight.Execute();
            commandHistory.Push(movePlatformRight);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            if (commandHistory.Count != 0)
            {
                //pop the last command off our stack
                Command lastCommand = commandHistory.Pop();

                //call Undo() on the last command
                lastCommand.Undo();
            }
        }
    }
}
