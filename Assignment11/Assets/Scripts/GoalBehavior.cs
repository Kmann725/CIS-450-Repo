/*
 * Kyle Manning
 * GoalBehavior.cs
 * Assignment 11
 * Destroys the door once a ball collides with the goal
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    public GameObject door;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            Destroy(door);
        }
    }
}
