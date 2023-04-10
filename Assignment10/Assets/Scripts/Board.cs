/*
 * Kyle Manning
 * Assignment 10
 * Board.cs
 * Handles boards being carried and dropped by player, and returns board to object pool
 * when it touches a laser
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    BoardPooler pooler;

    private GameObject player;

    public bool carried = false;

    private void Start()
    {
        pooler = BoardPooler.GetInstance();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (carried)
            {
                carried = false;
                GetComponent<Rigidbody>().isKinematic = false;
            }
            else if (Physics.Raycast(player.transform.position, player.transform.forward, out var hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject == gameObject && !carried)
                {
                    carried = true;
                    GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }

        if (carried)
        {
            CarriedPosition();
        }
    }

    private void CarriedPosition()
    {
        Vector3 newPos = player.transform.position;
        newPos += player.transform.forward * 6.5f;
        newPos.y = player.transform.position.y - 0.5f;
        transform.position = newPos;

        Quaternion newRot = player.transform.rotation;
        newRot.eulerAngles = new Vector3(0f, newRot.eulerAngles.y + 90, 0f);
        transform.rotation = newRot;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("laser"))
        {
            pooler.ReturnObject("board", gameObject);
        }
    }
}
