/*
 * Kyle Manning
 * PlayerMovement.cs
 * Assignment 9
 * Handles player movement, mouse look functionality, and being spotted by the target
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
    private float xRot;

    public bool sneaking = false;
    public bool spotted = false;
    public bool inVicinity = false;

    private Rigidbody rb;
    private GameObject target;

    public GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        target = GameObject.FindGameObjectWithTag("target");

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

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jump);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.localScale = new Vector3(1, 0.65f, 1);
            sneaking = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.localScale = new Vector3(1, 1, 1);
            sneaking = false;
        }
    }

    private void MouseLook()
    {
        float y = Input.GetAxis("Mouse X") * mouseSensitivity;
        xRot += Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.eulerAngles = new Vector3(-xRot, transform.eulerAngles.y + y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            canJump = true;
        }

        if (collision.gameObject.CompareTag("target"))
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            canJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("target vision"))
        {
            if (inVicinity || !sneaking)
            {
                spotted = true;
            }
        }

        if (other.gameObject.CompareTag("target vicinity"))
        {
            inVicinity = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("target vicinity"))
        {
            inVicinity = false;
        }
    }
}
