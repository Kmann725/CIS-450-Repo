/*
 * Kyle Manning
 * VideoGame.cs
 * Assignment 1
 * Creates a child class VideoGame for parent Game with interfaces IMedium and IPlayLength, present
 * in the UML diagram
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoGame : Game
{
    public string title;
    public int players;
    public string console;
    public int gameLength;

    public VideoGame()
    {
        title = "null";
        players = 1;
        console = "n/a";
        gameLength = 10;
    }

    public VideoGame(string name, int num, string system, int length)
    {
        title = name;
        players = num;
        console = system;
        gameLength = length;
    }

    public override void NumOfPlayers()
    {
        Debug.Log("The number of players for " + title + " is " + players);
    }

    public override void MediumType()
    {
        Debug.Log(title + " is played via: " + console);
    }

    public override void LengthOfPlay()
    {
        Debug.Log(title + " takes " + gameLength + " minutes to play");
    }
}
