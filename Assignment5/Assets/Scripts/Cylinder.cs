/*
 * Kyle Manning
 * Cylinder.cs
 * Assignment 5
 * Concrete class of Object carrying the override for cylinder objects' functionality
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : Object
{
    public override void DisplayInfo()
    {
        description.text = "Cylinder with mass of " + mass;
        StartCoroutine(ClearInfo());
    }
}
