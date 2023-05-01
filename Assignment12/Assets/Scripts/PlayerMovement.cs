/*
 * Kyle Manning
 * PlayerMovement.cs
 * Assignment 12
 * Handles player movement and mouse look functionality
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 5f;
    public float mouseSensitivity = 5f;
    private bool canJump = true;
    private bool hasKey = false;
    private float xRot;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        transform.position += movement * speed * Time.deltaTime;

        MouseLook();

        Interact();

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jump);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }

    private void MouseLook()
    {
        float y = Input.GetAxis("Mouse X") * mouseSensitivity;
        xRot += Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.eulerAngles = new Vector3(-xRot, transform.eulerAngles.y + y, 0);
    }

    private void Interact()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit, 15f))
            {
                if (hit.collider.CompareTag("chest"))
                {
                    hit.collider.gameObject.GetComponent<CompositeComponent>().UnpackContainer();
                }
                else if (hit.collider.CompareTag("key"))
                {
                    hasKey = true;
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("door") && hasKey)
                {
                    hasKey = false;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit, 15f))
            {
                if (hit.collider.CompareTag("chest"))
                {
                    hit.collider.gameObject.GetComponent<CompositeComponent>().UnpackCompletely();
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            canJump = false;
        }
    }
}
