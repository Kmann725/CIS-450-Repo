/*
 * Kyle Manning
 * LeafComponent.cs
 * Assignment 12
 * Leaf object for the pattern; contains method for starting a glow effect
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafComponent : Item
{
    public Light glow;

    public override void StartGlow()
    {
        StartCoroutine(Glowing());
    }

    IEnumerator Glowing()
    {
        while(true)
        {
            for (int i = 1; i <=30; i++)
            {
                glow.intensity = 0.1f * i;
                yield return new WaitForSeconds(0.05f);
            }

            for (int i = 1; i <= 30; i++)
            {
                glow.intensity = 3 - (0.1f * i);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
