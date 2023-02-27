/*
 * Kyle Manning
 * ForceGrenadeFactory.cs
 * Assignment 6
 * Concrete factory for making grenades which apply forces to objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGrenadeFactory : Factory
{
    public GameObject normalGrenade;
    public GameObject gravityWellGrenade;

    public override void CreateGrenade(int type)
    {
        Vector3 newPos = transform.position;
        newPos.x += 5;

        cooldown = true;
        switch (type)
        {
            case 1:
                Instantiate(normalGrenade, newPos, transform.rotation);
                button1.GetComponent<MeshRenderer>().material = pressed;
                break;
            case 2:
                Instantiate(gravityWellGrenade, newPos, transform.rotation);
                button2.GetComponent<MeshRenderer>().material = pressed;
                break;
        }

        StartCoroutine(FactoryCooldown());
    }
}
