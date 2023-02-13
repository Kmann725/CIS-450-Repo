/*
 * Kyle Manning
 * Shield.cs
 * Assignment 4
 * The base concrete component for shields
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : ShieldAbstract
{
    public ShieldAbstract shield;

    private void Start()
    {
        shield = GetComponent<ShieldAbstract>();
        health = 1;
    }

    public override int TakeDamage()
    {
        health--;
        return health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("laser"))
        {
            Destroy(other.gameObject);
            if (shield.TakeDamage() == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
