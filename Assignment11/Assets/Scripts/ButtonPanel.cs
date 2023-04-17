/*
 * Kyle Manning
 * ButtonPanel.cs
 * Assignment 11
 * Client for Facade Pattern; calls methods when buttons are pressed
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanel : MonoBehaviour
{
    private PlayerMovement player;
    private ButtonFacade facade;

    public Material unpressed;
    public Material pressed;

    public GameObject spawnButton;
    public GameObject switchBarrierButton;
    public GameObject jumpButton;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        facade = GameObject.FindGameObjectWithTag("facade").GetComponent<ButtonFacade>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(player.transform.position, player.transform.forward, out var hit, 15f))
            {
                if (hit.collider.gameObject == spawnButton)
                {
                    facade.SpawnSphere();
                    StartCoroutine(ButtonFeedback(spawnButton));
                }
                else if (hit.collider.gameObject == switchBarrierButton)
                {
                    facade.SwitchBarriers();
                    StartCoroutine(ButtonFeedback(switchBarrierButton));
                }
                else if (hit.collider.gameObject == jumpButton)
                {
                    facade.SphereJump();
                    StartCoroutine(ButtonFeedback(jumpButton));
                }
            }
        }
    }

    IEnumerator ButtonFeedback(GameObject button)
    {
        button.GetComponent<MeshRenderer>().material = pressed;

        yield return new WaitForSeconds(0.15f);

        button.GetComponent<MeshRenderer>().material = unpressed;
    }
}
