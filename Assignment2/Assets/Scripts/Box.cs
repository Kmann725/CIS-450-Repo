/*
 * Kyle Manning
 * Box.cs
 * Assignment 2
 * Client class for boxes. Handles switching box actions and calling methods
 * to perform those actions, as well as playing sounds for player feedback
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    BoxAction boxAction;

    private GameObject player;
    private AudioSource sound;

    public AudioClip grow;
    public AudioClip shrink;
    public AudioClip fail;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetAction(new Grow());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetAction(new Shrink());
        }

        if (Input.GetMouseButtonDown(0))
        {
            PerformAction();
        }
    }

    private void SetAction(BoxAction action)
    {
        if (action.GetType().ToString() == "Grow")
        {
            Destroy(GetComponent<Shrink>());
            boxAction = gameObject.AddComponent<Grow>();
        }
        else
        {
            Destroy(GetComponent<Grow>());
            boxAction = gameObject.AddComponent<Shrink>();
        }
    }

    private void PerformAction()
    {
        Vector3 reticle = player.transform.position;
        reticle.y += 0.67f;

        if (Physics.Raycast(reticle, player.transform.forward, out var hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if ((transform.localScale.x == 10 && GetComponent<Grow>() != null) || (transform.localScale.x == 1 && GetComponent<Shrink>() != null))
                {
                    sound.PlayOneShot(fail);
                }
                else if (GetComponent<Grow>() != null)
                {
                    sound.PlayOneShot(grow);
                }
                else
                {
                    sound.PlayOneShot(shrink);
                }
                boxAction.Action();
            }
        }
    }
}
