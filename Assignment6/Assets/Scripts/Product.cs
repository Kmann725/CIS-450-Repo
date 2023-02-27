/*
 * Kyle Manning
 * Product.cs
 * Assignment 6
 * The abstract class for all product objects; contains shared functionality for picking
 * up and throwing grenades
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Product : MonoBehaviour
{
    public float throwStrength = 1000f;
    public float explosionRadius = 5f;
    public float explosionStrength = 500f;
    public bool carried = false;
    public bool thrown = false;

    private Rigidbody rb;
    private GameObject player;
    private GameObject carrySpot;

    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        carrySpot = GameObject.FindGameObjectWithTag("Carry");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 reticle = player.transform.position;

            if (Physics.Raycast(reticle, player.transform.forward, out var hit, Mathf.Infinity) && !carried)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    carried = true;
                }
            }
            else
            {
                carried = false;
                thrown = true;
                rb.AddForce(player.transform.forward * throwStrength);
                rb.AddForce(Vector3.up * 300f);
            }
        }

        if (carried)
        {
            transform.position = carrySpot.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (thrown)
        {
            Explode();
        }
    }

    public abstract void Explode();
}
