/*
 * Kyle Manning
 * TargetBehavior.cs
 * Assignment 9
 * Handles behavior of the target and calling state manager methods
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetBehavior : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement pm;
    private NavMeshAgent agent;
    private TargetStateManager targetStateManager;
    private AudioSource src;

    public GameObject targetVicinity;

    public bool runningAway = false;
    public bool searching = false;
    public Vector3 newPos;

    public float targetRadius = 5f;
    public float moveDistance = 10f;

    public AudioClip startSearch;
    public AudioClip stopSearch;
    public AudioClip running;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerMovement>();
        targetStateManager = GetComponent<TargetStateManager>();
        src = GetComponent<AudioSource>();

        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < targetRadius && !runningAway)
        {
            targetStateManager.StartSearching();
            if (!searching)
            {
                targetVicinity.SetActive(true);
                src.PlayOneShot(startSearch);
            }
            searching = true;
        }
        else if (searching)
        {
            targetStateManager.StopSearching();
            src.PlayOneShot(stopSearch);
            searching = false;
            targetVicinity.SetActive(false);
        }

        if (pm.spotted && searching)
        {
            targetStateManager.StartRunning();
            src.PlayOneShot(running);
            runningAway = true;
            searching = false;
        }

        if (agent.remainingDistance < 0.15f && runningAway)
        {
            targetStateManager.StopRunning();
            pm.spotted = false;
            runningAway = false;
        }
    }
}
