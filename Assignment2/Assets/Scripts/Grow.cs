/*
 * Kyle Manning
 * Grow.cs
 * Assignment 2
 * Concrete sub-class of BoxAction, increases the size of the box
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : BoxAction
{
    public override void Action()
    {
        if (transform.localScale.x < 10)
        {
            transform.localScale += new Vector3(1, 1, 1);
        }
    }
}
