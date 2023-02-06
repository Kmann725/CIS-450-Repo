/*
 * Kyle Manning
 * Panel.cs
 * Assignment 3
 * Subject object class; gets observers on start, stores and updates an integer value
 * equal to the sum of all currently active buttons, and sends this integer to the observers
 * whenever a button is activated or deactivated
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour, ISubject
{
    List<IObserver> observers = new List<IObserver>();

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public int button1Value = 10;
    public int button2Value = 10;
    public int button3Value = 10;

    private int charge = 0;

    public Material button;
    public Material pressed;

    private bool button1Pressed = false;
    private bool button2Pressed = false;
    private bool button3Pressed = false;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] obs = GameObject.FindGameObjectsWithTag("door");

        foreach(GameObject obj in obs)
        {
            RegisterObserver(obj.GetComponent<Door>());
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ButtonPress();
        }
    }

    public void RegisterObserver(IObserver obs)
    {
        observers.Add(obs);
    }

    public void RemoveObserver(IObserver obs)
    {
        observers.Remove(obs);
    }

    public void NotifyObservers()
    {
        foreach(IObserver obs in observers)
        {
            obs.RenewObserver(charge);
        }
    }

    private void ButtonPress()
    {
        Vector3 reticle = player.transform.position;

        if (Physics.Raycast(reticle, player.transform.forward, out var hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject == button1)
            {
                if (!button1Pressed)
                {
                    button1Pressed = true;
                    button1.GetComponent<MeshRenderer>().material = pressed;
                    charge += button1Value;
                    NotifyObservers();
                }
                else
                {
                    button1Pressed = false;
                    button1.GetComponent<MeshRenderer>().material = button;
                    charge -= button1Value;
                    NotifyObservers();
                }
            }
            else if (hit.collider.gameObject == button2)
            {
                if (!button2Pressed)
                {
                    button2Pressed = true;
                    button2.GetComponent<MeshRenderer>().material = pressed;
                    charge += button2Value;
                    NotifyObservers();
                }
                else
                {
                    button2Pressed = false;
                    button2.GetComponent<MeshRenderer>().material = button;
                    charge -= button2Value;
                    NotifyObservers();
                }
            }
            else if (hit.collider.gameObject == button3)
            {
                if (!button3Pressed)
                {
                    button3Pressed = true;
                    button3.GetComponent<MeshRenderer>().material = pressed;
                    charge += button3Value;
                    NotifyObservers();
                }
                else
                {
                    button3Pressed = false;
                    button3.GetComponent<MeshRenderer>().material = button;
                    charge -= button3Value;
                    NotifyObservers();
                }
            }
        }
    }
}
