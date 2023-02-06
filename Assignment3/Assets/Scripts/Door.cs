/*
 * Kyle Manning
 * Door.cs
 * Assignment 3
 * Observer object class; raises and changes its counter in response
 * to changes from the panel subject class
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour, IObserver
{
    public int doorCharge = 10;

    public TextMeshPro doorText;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    public void RenewObserver(int i)
    {
        doorText.text = "" + (doorCharge - i);
        Vector3 newPos = transform.position;

        if (i <= doorCharge)
        {
            newPos.y = startPos.y + ((i / (float)doorCharge) * 2.5f);
        }
        else
        {
            newPos.y = startPos.y;
        }

        transform.position = newPos;
    }
}
