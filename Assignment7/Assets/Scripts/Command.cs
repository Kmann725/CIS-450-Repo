/*
 * Kyle Manning
 * Command.cs
 * Assignment 7
 * Interface used by concrete commands
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Command
{
    public void Execute();

    public void Undo();
}
