/*
 * Kyle Manning
 * Platform.cs
 * Assignment 5
 * Behavior for the platforms which open the door. If the correct object is placed on it
 * it raises the door. If the correct object is removed it lowers the door.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int shape;
    public int mass;
    public GameObject door;
    public Material platform;
    public Material correct;

    private float height = 0.9f;

    private void OnCollisionEnter(Collision collision)
    {
        switch (shape)
        {
            case 1:
                if (collision.gameObject.GetComponent<Box>() != null && collision.gameObject.GetComponent<Box>().mass == mass)
                {
                    Vector3 newDoorPos = door.transform.position;
                    newDoorPos.y += height;
                    door.transform.position = newDoorPos;
                    GetComponent<MeshRenderer>().material = correct;
                }
                break;
            case 2:
                if (collision.gameObject.GetComponent<Cylinder>() != null && collision.gameObject.GetComponent<Cylinder>().mass == mass)
                {
                    Vector3 newDoorPos = door.transform.position;
                    newDoorPos.y += height;
                    door.transform.position = newDoorPos;
                    GetComponent<MeshRenderer>().material = correct;
                }
                break;
            case 3:
                if (collision.gameObject.GetComponent<Ball>() != null && collision.gameObject.GetComponent<Ball>().mass == mass)
                {
                    Vector3 newDoorPos = door.transform.position;
                    newDoorPos.y += height;
                    door.transform.position = newDoorPos;
                    GetComponent<MeshRenderer>().material = correct;
                }
                break;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        switch (shape)
        {
            case 1:
                if (collision.gameObject.GetComponent<Box>() != null && collision.gameObject.GetComponent<Box>().mass == mass)
                {
                    Vector3 newDoorPos = door.transform.position;
                    newDoorPos.y -= height;
                    door.transform.position = newDoorPos;
                    GetComponent<MeshRenderer>().material = platform;
                }
                break;
            case 2:
                if (collision.gameObject.GetComponent<Cylinder>() != null && collision.gameObject.GetComponent<Cylinder>().mass == mass)
                {
                    Vector3 newDoorPos = door.transform.position;
                    newDoorPos.y -= height;
                    door.transform.position = newDoorPos;
                    GetComponent<MeshRenderer>().material = platform;
                }
                break;
            case 3:
                if (collision.gameObject.GetComponent<Ball>() != null && collision.gameObject.GetComponent<Ball>().mass == mass)
                {
                    Vector3 newDoorPos = door.transform.position;
                    newDoorPos.y -= height;
                    door.transform.position = newDoorPos;
                    GetComponent<MeshRenderer>().material = platform;
                }
                break;
        }
    }
}
