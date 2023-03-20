/*
 * Kyle Manning
 * MovePlatformLeft.cs
 * Assignment 7
 * Concrete command for moving platforms to the left
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformLeft : MonoBehaviour, Command
{
    PlatformMover platform1;
    PlatformMover platform2;
    PlatformMover platform3;

    public Stack<Vector3> plat1Pos;
    public Stack<Vector3> plat2Pos;
    public Stack<Vector3> plat3Pos;

    public MovePlatformLeft(PlatformMover platform1, PlatformMover platform2, PlatformMover platform3)
    {
        this.platform1 = platform1;
        this.platform2 = platform2;
        this.platform3 = platform3;

        plat1Pos = new Stack<Vector3>();
        plat2Pos = new Stack<Vector3>();
        plat3Pos = new Stack<Vector3>();
    }

    public void Execute()
    {
        plat1Pos.Push(platform1.gameObject.transform.position);
        plat2Pos.Push(platform2.gameObject.transform.position);
        plat3Pos.Push(platform3.gameObject.transform.position);

        platform1.MoveLeft();
        platform2.MoveLeft();
        platform3.MoveLeft();
    }

    public void Undo()
    {
        if (plat1Pos.Count != 0)
        {
            Vector3 previosPos = plat1Pos.Pop();

            if (previosPos != platform1.gameObject.transform.position)
            {
                platform1.MoveRight();
            }
        }

        if (plat2Pos.Count != 0)
        {
            Vector3 previosPos = plat2Pos.Pop();

            if (previosPos != platform2.gameObject.transform.position)
            {
                platform2.MoveRight();
            }
        }

        if (plat3Pos.Count != 0)
        {
            Vector3 previosPos = plat3Pos.Pop();

            if (previosPos != platform3.gameObject.transform.position)
            {
                platform3.MoveRight();
            }
        }
    }
}
