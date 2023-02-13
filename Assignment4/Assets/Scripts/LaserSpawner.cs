/*
 * Kyle Manning
 * LaserSpawner.cs
 * Assignment 4
 * Handles spawning of lasers
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnLaser", 10, 5);
    }

    private void SpawnLaser()
    {
        Instantiate(laser, transform.position, transform.rotation);
    }
}
