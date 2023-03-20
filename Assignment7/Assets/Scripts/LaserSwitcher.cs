/*
 * Kyle Manning
 * LaserSwitcher.cs
 * Assignment 7
 * Reciever for SwitchLasers command; switches which set of lasers are active
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitcher : MonoBehaviour
{
    public GameObject[] laserSet1;
    public GameObject[] laserSet2;
    public GameObject[] laserSet3;

    public int activeSet = 1;

    public void Switch()
    {
        activeSet++;

        if (activeSet > 3)
        {
            activeSet = 1;
        }

        if (activeSet == 1)
        {
            foreach (GameObject laser in laserSet1)
            {
                laser.SetActive(true);
            }
            foreach (GameObject laser in laserSet3)
            {
                laser.SetActive(false);
            }
            foreach (GameObject laser in laserSet2)
            {
                laser.SetActive(false);
            }
        }
        else if (activeSet == 2)
        {
            foreach (GameObject laser in laserSet1)
            {
                laser.SetActive(false);
            }
            foreach (GameObject laser in laserSet2)
            {
                laser.SetActive(true);
            }
            foreach (GameObject laser in laserSet3)
            {
                laser.SetActive(false);
            }
        }
        else if (activeSet == 3)
        {
            foreach (GameObject laser in laserSet3)
            {
                laser.SetActive(true);
            }
            foreach (GameObject laser in laserSet2)
            {
                laser.SetActive(false);
            }
            foreach (GameObject laser in laserSet1)
            {
                laser.SetActive(false);
            }
        }
    }
}
