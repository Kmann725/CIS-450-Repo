/*
 * Kyle Manning
 * SpawnBall.cs
 * Assignment 11
 * Subclass for Facade Pattern; spawns/resets balls and returns BallJump subclass to the Facade
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject sphere;

    private GameObject currentSphere = null;

    public void SpawnSphere()
    {
        if (currentSphere != null)
        {
            Destroy(currentSphere.gameObject);
        }

        currentSphere = Instantiate(sphere, transform.position, transform.rotation);
    }

    public BallJump ReturnJumper()
    {
        return currentSphere.GetComponent<BallJump>();
    }
}
