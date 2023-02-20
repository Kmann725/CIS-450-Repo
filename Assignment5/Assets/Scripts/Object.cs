/*
 * Kyle Manning
 * Object.cs
 * Assignment 5
 * The abstract class for objects created by the factory. Contains
 * shared functionalities for the different concrete classes.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Object : MonoBehaviour
{
    public int mass;
    public bool carried = false;
    public TextMeshProUGUI description;

    protected GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        description = GameObject.FindGameObjectWithTag("description").GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 reticle = player.transform.position;

            if (Physics.Raycast(reticle, player.transform.forward, out var hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject == gameObject && !carried)
                {
                    carried = true;
                }
                else
                {
                    carried = false;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 reticle = player.transform.position;

            if (Physics.Raycast(reticle, player.transform.forward, out var hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    DisplayInfo();
                }
            }
        }

        if (carried)
        {
            Vector3 newPos = player.transform.position;
            newPos += player.transform.forward * 3;
            newPos.y = player.transform.position.y;
            transform.position = newPos;
        }
    }

    public abstract void DisplayInfo();

    protected IEnumerator ClearInfo()
    {
        yield return new WaitForSeconds(5f);

        description.text = "";
    }
}
