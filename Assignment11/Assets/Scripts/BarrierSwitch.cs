/*
 * Kyle Manning
 * BarrierSwitch.cs
 * Assignment 11
 * Subclass for Facade Pattern; switches the active group of barriers in the track
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSwitch : MonoBehaviour
{
    public GameObject barriers1;
    public GameObject barriers2;

    public void SwitchBarriers()
    {
        if(barriers1.activeInHierarchy)
        {
            barriers1.SetActive(false);
            barriers2.SetActive(true);
        }
        else
        {
            barriers1.SetActive(true);
            barriers2.SetActive(false);
        }
    }
}
