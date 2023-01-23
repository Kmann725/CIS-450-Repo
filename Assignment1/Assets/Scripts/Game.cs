/*
 * Kyle Manning
 * Game.cs
 * Assignment 1
 * The abstract class Game which contains an abstract class used for displaying
 * number of players
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Game : IMedium, IPlayLength
{
    public abstract void NumOfPlayers();

    public abstract void MediumType();

    public abstract void LengthOfPlay();
}
