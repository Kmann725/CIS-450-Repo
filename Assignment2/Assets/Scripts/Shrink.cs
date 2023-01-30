/*
 * Kyle Manning
 * Shrink.cs
 * Assignment 2
 * Concrete sub-class of BoxAction, decreases the size of the box
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : BoxAction
{
    public override void Action()
    {
        if (transform.localScale.x > 1)
        {
            transform.localScale += new Vector3(-1, -1, -1);
        }
    }
}
