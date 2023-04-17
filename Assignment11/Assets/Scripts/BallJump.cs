/*
 * Kyle Manning
 * BallJump.cs
 * Assignment 11
 * Subclass for Facade Pattern; makes the ball jump
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJump : MonoBehaviour
{
    private Rigidbody rb;

    public float jumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }
}
