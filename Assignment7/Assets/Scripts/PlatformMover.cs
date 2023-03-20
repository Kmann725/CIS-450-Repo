/*
 * Kyle Manning
 * PlatformMover.cs
 * Assignment 7
 * Reciever for the MovePlatformLeft and MovePlatformRight commands; moves platforms left and right
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public float leftMostPos;
    public float rightMostPos;

    private bool playerStanding = false;

    public void MoveLeft()
    {
        if (!playerStanding && transform.position.x > leftMostPos)
        {
            transform.position += new Vector3(-1, 0, 0);
        }
    }

    public void MoveRight()
    {
        if (!playerStanding && transform.position.x < rightMostPos)
        {
            transform.position += new Vector3(1, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStanding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStanding = false;
        }
    }
}
