/*
 * Kyle Manning
 * Box.cs
 * Assignment 5
 * Concrete class of Object carrying the override for box objects' functionality
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Object
{
    public override void DisplayInfo()
    {
        description.text = "Box with mass of " + mass;
        StartCoroutine(ClearInfo());
    }
}
