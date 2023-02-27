/*
 * Kyle Manning
 * GravityWellGrenade.cs
 * Assignment 6
 * Concrete product; pulls objects towards it when the grenade explodes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWellGrenade : Product
{
    public override void Explode()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in cols)
        {
            if (col.gameObject.GetComponent<Rigidbody>() && !col.gameObject.CompareTag("Player"))
            {
                Vector3 direction = transform.position - col.gameObject.transform.position;
                col.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * explosionStrength);
            }
        }

        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
