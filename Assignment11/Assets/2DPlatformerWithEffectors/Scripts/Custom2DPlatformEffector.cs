using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom2DPlatformEffector : MonoBehaviour
{
    private EdgeCollider2D col;

    //Set collider reference on Awake
    private void Awake()
    {
        col = gameObject.GetComponent<EdgeCollider2D>();  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //if the player is above the platform, then
            if(collision.transform.position.y - collision.bounds.size.y > transform.position.y)
            {
                col.isTrigger = false;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //if the player is above the platform, then
            if (collision.transform.position.y - collision.collider.bounds.size.y < transform.position.y)
            {
                col.isTrigger = true;
            }
        }
    }


}
