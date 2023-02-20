/*
 * Kyle Manning
 * Panel.cs
 * Assignment 5
 * Handles behavior for the buttons and selecting options for object
 * creation. Sends call to factory object when the make button is
 * clicked on.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject boxButton;
    public GameObject cylinderButton;
    public GameObject ballButton;
    public GameObject smallButton;
    public GameObject mediumButton;
    public GameObject largeButton;
    public GameObject makeButton;

    public ObjectMaker factory;

    public Material button;
    public Material pressed;

    private bool boxButtonPressed = false;
    private bool cylinderButtonPressed = false;
    private bool ballButtonPressed = false;
    private bool smallButtonPressed = false;
    private bool mediumButtonPressed = false;
    private bool largeButtonPressed = false;

    private int shape = 0;
    private int mass = 0;

    public GameObject player;

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

        if (Physics.Raycast(reticle, player.transform.forward, out var hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject == boxButton && !boxButtonPressed)
            {
                shape = 1;
                boxButtonPressed = true;
                boxButton.GetComponent<MeshRenderer>().material = pressed;
                cylinderButtonPressed = false;
                cylinderButton.GetComponent<MeshRenderer>().material = button;
                ballButtonPressed = false;
                ballButton.GetComponent<MeshRenderer>().material = button;
            }
            else if (hit.collider.gameObject == cylinderButton && !cylinderButtonPressed)
            {
                shape = 2;
                cylinderButtonPressed = true;
                cylinderButton.GetComponent<MeshRenderer>().material = pressed;
                boxButtonPressed = false;
                boxButton.GetComponent<MeshRenderer>().material = button;
                ballButtonPressed = false;
                ballButton.GetComponent<MeshRenderer>().material = button;
            }
            else if (hit.collider.gameObject == ballButton && !ballButtonPressed)
            {
                shape = 3;
                ballButtonPressed = true;
                ballButton.GetComponent<MeshRenderer>().material = pressed;
                boxButtonPressed = false;
                boxButton.GetComponent<MeshRenderer>().material = button;
                cylinderButtonPressed = false;
                cylinderButton.GetComponent<MeshRenderer>().material = button;
            }

            if (hit.collider.gameObject == smallButton && !smallButtonPressed)
            {
                mass = 1;
                smallButtonPressed = true;
                smallButton.GetComponent<MeshRenderer>().material = pressed;
                mediumButtonPressed = false;
                mediumButton.GetComponent<MeshRenderer>().material = button;
                largeButtonPressed = false;
                largeButton.GetComponent<MeshRenderer>().material = button;
            }
            else if (hit.collider.gameObject == mediumButton && !mediumButtonPressed)
            {
                mass = 2;
                mediumButtonPressed = true;
                mediumButton.GetComponent<MeshRenderer>().material = pressed;
                smallButtonPressed = false;
                smallButton.GetComponent<MeshRenderer>().material = button;
                largeButtonPressed = false;
                largeButton.GetComponent<MeshRenderer>().material = button;
            }
            else if (hit.collider.gameObject == largeButton && !largeButtonPressed)
            {
                mass = 3;
                largeButtonPressed = true;
                largeButton.GetComponent<MeshRenderer>().material = pressed;
                mediumButtonPressed = false;
                mediumButton.GetComponent<MeshRenderer>().material = button;
                smallButtonPressed = false;
                smallButton.GetComponent<MeshRenderer>().material = button;
            }

            if (hit.collider.gameObject == makeButton && shape != 0 && mass != 0)
            {
                OrderShape();
            }
        }
    }

    private void OrderShape()
    {
        makeButton.GetComponent<MeshRenderer>().material = pressed;
        StartCoroutine(Reactivate());
        factory.CreateShape(shape, mass);

        boxButtonPressed = false;
        boxButton.GetComponent<MeshRenderer>().material = button;
        cylinderButtonPressed = false;
        cylinderButton.GetComponent<MeshRenderer>().material = button;
        ballButtonPressed = false;
        ballButton.GetComponent<MeshRenderer>().material = button;

        smallButtonPressed = false;
        smallButton.GetComponent<MeshRenderer>().material = button;
        mediumButtonPressed = false;
        mediumButton.GetComponent<MeshRenderer>().material = button;
        largeButtonPressed = false;
        largeButton.GetComponent<MeshRenderer>().material = button;
    }

    IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(1.5f);

        makeButton.GetComponent<MeshRenderer>().material = button;
        shape = 0;
        mass = 0;
    }
}
