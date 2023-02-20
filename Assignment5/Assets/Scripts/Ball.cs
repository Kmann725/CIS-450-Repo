/*
 * Kyle Manning
 * Ball.cs
 * Assignment 5
 * Concrete class of Object carrying the override for ball objects' functionality
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Object
{
    public override void DisplayInfo()
    {
        description.text = "Ball with mass of " + mass;
        StartCoroutine(ClearInfo());
    }
}
