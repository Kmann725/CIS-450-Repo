
/*
 * Kyle Manning
 * ShrinkGrenade.cs
 * Assignment 6
 * Concrete product; shrinks objects when the grenade explodes
 */using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkGrenade : Product
{
    public override void Explode()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in cols)
        {
            if (col.gameObject.GetComponent<Rigidbody>() && !col.gameObject.CompareTag("Player"))
            {
                col.gameObject.transform.localScale *= 0.3f;
            }
        }

        Instantiate(explosionEffect, transform.position, explosionEffect.transform.rotation);
        Destroy(gameObject);
    }
}
