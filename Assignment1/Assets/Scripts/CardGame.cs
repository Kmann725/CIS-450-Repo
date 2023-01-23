/*
 * Kyle Manning
 * CardGame.cs
 * Assignment 1
 * Creates a child class CardGame for parent Game with interfaces IMedium and IPlayLength, not present
 * in the UML diagram
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGame : Game
{
    public string title;
    public int players;
    public string cardType;
    public int gameLength;

    public CardGame()
    {
        title = "null";
        players = 1;
        cardType = "n/a";
        gameLength = 10;
    }

    public CardGame(string name, int num, string cards, int length)
    {
        title = name;
        players = num;
        cardType = cards;
        gameLength = length;
    }

    public override void NumOfPlayers()
    {
        Debug.Log("The number of players for " + title + " is " + players);
    }

    public override void MediumType()
    {
        Debug.Log(title + " is played via: " + cardType);
    }

    public override void LengthOfPlay()
    {
        Debug.Log(title + " takes " + gameLength + " minutes to play");
    }
}
