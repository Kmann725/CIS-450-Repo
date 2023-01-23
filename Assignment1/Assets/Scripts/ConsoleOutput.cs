/*
 * Kyle Manning
 * ConsoleOutput.cs
 * Assignment 1
 * Creates instances of objects and tests their use of abstact and interface methods
 * through user input triggers
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleOutput : MonoBehaviour
{
    public List<Game> Games;

    // Start is called before the first frame update
    void Start()
    {
        BoardGame boardTest = new BoardGame();
        VideoGame videoTest = new VideoGame();

        boardTest.NumOfPlayers();
        boardTest.MediumType();
        boardTest.LengthOfPlay();

        videoTest.NumOfPlayers();
        videoTest.MediumType();
        videoTest.LengthOfPlay();

        Games = new List<Game>
        {
            new BoardGame("Monopoly", 6, "circuit-type board", 75),
            new BoardGame("Candy Land", 4, "linear-type board", 45),
            new VideoGame("The World Ends With You", 1, "Nintendo Switch", 1800),
            new VideoGame("Mario Party Superstars", 4, "Nintendo Switch", 60),
            new CardGame("Spoons", 5, "Standard Playing Cards", 20)
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach(Game game in Games)
            {
                game.NumOfPlayers();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (Game game in Games)
            {
                game.LengthOfPlay();
            }
        }
    }
}
