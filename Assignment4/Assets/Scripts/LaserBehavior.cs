/*
 * Kyle Manning
 * LaserBehavior.cs
 * Assignment 4
 * Handles the movement of laser objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.back * speed * Time.deltaTime);
    }
}
