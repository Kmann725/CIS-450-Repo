/*
 * Kyle Manning
 * Assignment 10
 * BoardSpawnerButton.cs
 * Handles spawning objects from the object pool when the button is pressed
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpawnerButton : MonoBehaviour
{
    BoardPooler pooler;

    private GameObject player;
    private GameObject spawnPos;
    private AudioSource src;

    public Material button;
    public Material pressed;
    public AudioClip spawning;

    // Start is called before the first frame update
    void Start()
    {
        pooler = BoardPooler.GetInstance();

        player = GameObject.FindGameObjectWithTag("Player");
        spawnPos = GameObject.FindGameObjectWithTag("spawn");
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(player.transform.position, player.transform.forward, out var hit, 15f))
            {
                if (hit.collider.gameObject == gameObject && pooler.poolDic["board"].Count != 0)
                {
                    src.PlayOneShot(spawning);
                    StartCoroutine(SpawnBoards());
                    StartCoroutine(ButtonCooldown());
                }
            }
        }
    }

    IEnumerator SpawnBoards()
    {
        int boardCount = pooler.poolDic["board"].Count;

        for (int i = 0; i < boardCount; i++)
        {
            pooler.SpawnObject("board", spawnPos);

            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator ButtonCooldown()
    {
        GetComponent<MeshRenderer>().material = pressed;

        yield return new WaitForSeconds(1.5f);

        GetComponent<MeshRenderer>().material = button;
    }
}
