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

    public GameObject CreateShape(int shape)
    {
        GameObject newObj;

        switch (shape)
        {
            case 1:
                newObj = box;
                break;
            case 2:
                newObj = cylinder;
                break;
            case 3:
                newObj = ball;
                break;
            default:
                newObj = box;
                break;
        }

        return newObj;
    }

    public GameObject AddScript(GameObject instance, int shape, int mass)
    {
        GameObject obj = instance;

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
                obj.AddComponent<Box>();
                obj.GetComponent<Box>().mass = newMass;
                break;
            case 2:
                obj.AddComponent<Cylinder>();
                obj.GetComponent<Cylinder>().mass = newMass;
                break;
            case 3:
                obj.AddComponent<Ball>();
                obj.GetComponent<Ball>().mass = newMass;
                break;
        }

        return obj;
    }
}
