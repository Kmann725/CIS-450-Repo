/*
 * Kyle Manning
 * PropertyGrenadeFactory.cs
 * Assignment 6
 * Concrete factory for making grenades which edit an object's properties
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyGrenadeFactory : Factory
{
    public GameObject zeroGravGrenade;
    public GameObject shrinkGrenade;

    public override void CreateGrenade(int type)
    {
        Vector3 newPos = transform.position;
        newPos.x += 5;

        cooldown = true;
        switch (type)
        {
            case 1:
                Instantiate(zeroGravGrenade, newPos, transform.rotation);
                button1.GetComponent<MeshRenderer>().material = pressed;
                break;
            case 2:
                Instantiate(shrinkGrenade, newPos, transform.rotation);
                button2.GetComponent<MeshRenderer>().material = pressed;
                break;
        }

        StartCoroutine(FactoryCooldown());
    }
}
