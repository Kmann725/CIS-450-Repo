/*
 * Kyle Manning
 * PlayerMovement.cs
 * Assignment 4
 * Handles player movement and mouse look functionality; handles spawning shields
 * and adding decorators to them
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 5f;
    public float mouseSensitivity = 5f;
    private bool canJump = true;
    private float xRot;
    private bool canShield = true;

    private Rigidbody rb;

    public GameObject lose;
    public GameObject shield;
    public Image reticle;
    public Color able;
    public Color reload;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

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

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jump);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetMouseButtonDown(0) && canShield)
        {
            MakeShield();
            StartCoroutine(Reloading());
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddShieldStrengthener();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddShieldEnlarger();
        }
    }

    private void MouseLook()
    {
        float y = Input.GetAxis("Mouse X") * mouseSensitivity;
        xRot += Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.eulerAngles = new Vector3(-xRot, transform.eulerAngles.y + y, 0);
    }

    private void MakeShield()
    {
        Vector3 shieldPos = transform.position + (Vector3.forward * 3);
        Instantiate(shield, shieldPos, new Quaternion(0, 0, 0, 0));
    }

    private void AddShieldStrengthener()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("shield"))
            {
                Shield shield = hit.collider.gameObject.GetComponent<Shield>();

                shield.shield = new ShieldStrengthener(shield);

                hit.collider.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void AddShieldEnlarger()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("shield"))
            {
                Shield shield = hit.collider.gameObject.GetComponent<Shield>();

                shield.shield = new ShieldEnlarger(shield, shield.health);

                hit.collider.transform.localScale = hit.collider.transform.localScale * 2;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("laser"))
        {
            lose.SetActive(true);
            Time.timeScale = 0;
        }
    }

    IEnumerator Reloading()
    {
        canShield = false;
        reticle.color = reload;

        yield return new WaitForSeconds(4f);

        canShield = true;
        reticle.color = able;
    }
}
