/*
 * Kyle Manning
 * ObjectMaker.cs
 * Assignment 5
 * The factory object. Handles object creation based on information
 * passed from the client (Panel).
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaker : MonoBehaviour
{
    public GameObject box;
    public GameObject cylinder;
    public GameObject ball;

    public Vector3 objSpawn;

    public void CreateShape(int shape, int mass)
    {
        GameObject newObj;

        int newMass = 0;

        switch (mass)
        {
            case 1:
                newMass = 50;
                break;
            case 2:
                newMass = 100;
                break;
            case 3:
                newMass = 150;
                break;
        }

        switch (shape)
        {
            case 1:
                newObj = Instantiate(box, objSpawn, transform.rotation);
                newObj.AddComponent<Box>();
                newObj.GetComponent<Box>().mass = newMass;
                break;
            case 2:
                newObj = Instantiate(cylinder, objSpawn, transform.rotation);
                newObj.AddComponent<Cylinder>();
                newObj.GetComponent<Cylinder>().mass = newMass;
                break;
            case 3:
                newObj = Instantiate(ball, objSpawn, transform.rotation);
                newObj.AddComponent<Ball>();
                newObj.GetComponent<Ball>().mass = newMass;
                break;
            default:
                newObj = box;
                break;
        }
    }
}
