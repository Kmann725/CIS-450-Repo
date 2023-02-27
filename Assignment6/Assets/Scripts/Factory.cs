/*
 * Kyle Manning
 * Factory.cs
 * Assignment 6
 * The abstract class for factory objects; contains all shared functionality
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    public bool cooldown = false;

    public Material button;
    public Material pressed;

    public GameObject player;
    public GameObject button1;
    public GameObject button2;

    private AudioSource src;

    public AudioClip clank;

    private void Start()
    {
        src = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ButtonPress();
        }
    }

    private void ButtonPress()
    {
        Vector3 reticle = player.transform.position;

        if (Physics.Raycast(reticle, player.transform.forward, out var hit, Mathf.Infinity) && !cooldown)
        {
            if (hit.collider.gameObject == button1)
            {
                CreateGrenade(1);
                src.PlayOneShot(clank);
            }
            else if (hit.collider.gameObject == button2)
            {
                CreateGrenade(2);
                src.PlayOneShot(clank);
            }
        }
    }

    public abstract void CreateGrenade(int type);

    protected IEnumerator FactoryCooldown()
    {
        yield return new WaitForSeconds(4f);

        button1.GetComponent<MeshRenderer>().material = button;
        button2.GetComponent<MeshRenderer>().material = button;

        cooldown = false;
    }
}
