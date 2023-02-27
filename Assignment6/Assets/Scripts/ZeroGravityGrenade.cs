/*
 * Kyle Manning
 * ZeroGravityGrenade.cs
 * Assignment 6
 * Concrete product; launches objects away and disables object gravity when the grenade explodes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravityGrenade : Product
{
    public override void Explode()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in cols)
        {
            if (col.gameObject.GetComponent<Rigidbody>() && !col.gameObject.CompareTag("Player"))
            {
                Vector3 direction = col.gameObject.transform.position - transform.position;
                col.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * explosionStrength);
                col.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
        }

        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
