/*
 * Kyle Manning
 * BoardGame.cs
 * Assignment 1
 * Creates a child class BoardGame for parent Game with interfaces IMedium and IPlayLength, present
 * in the UML diagram
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGame : Game
{
    public string title;
    public int players;
    public string boardType;
    public int gameLength;

    public BoardGame()
    {
        title = "null";
        players = 1;
        boardType = "n/a";
        gameLength = 10;
    }

    public BoardGame(string name, int num, string board, int length)
    {
        title = name;
        players = num;
        boardType = board;
        gameLength = length;
    }

    public override void NumOfPlayers()
    {
        Debug.Log("The number of players for " + title + " is " + players);
    }

    public override void MediumType()
    {
        Debug.Log(title + " is played via: " + boardType);
    }

    public override void LengthOfPlay()
    {
        Debug.Log(title + " takes " + gameLength + " minutes to play");
    }
}
