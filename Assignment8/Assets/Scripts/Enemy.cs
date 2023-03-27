using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected GameObject player;
    public GameObject awarenessLight;
    public GameObject awarenessRange;
    public AudioClip playerSpotted;
    public AudioClip playerLost;
    private AudioSource src;

    public float speed = 4.5f;
    public float radius = 10f;

    protected bool atPoint = false;
    protected bool playerInRange = false;
    protected bool chasingPlayer = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        src = GetComponent<AudioSource>();
    }

    private void Update()
    {
        EnemyBehvior();
    }

    private void EnemyBehvior()
    {
        Movement();

        if (AtPoint())
        {
            StartCoroutine(WaitAtPoint());
        }

        if (PlayerInRange())
        {
            ChasePlayer();
        }
    }

    public abstract void Movement();

    public void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public virtual bool AtPoint()
    {
        return atPoint;
    }

    public virtual bool PlayerInRange()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider col in cols)
        {
            if (col.gameObject.tag == "Player")
            {
                if (!playerInRange)
                {
                    src.PlayOneShot(playerSpotted);
                }
                awarenessRange.SetActive(false);
                awarenessLight.SetActive(true);
                chasingPlayer = true;
                return playerInRange = true;
            }
        }

        if (playerInRange)
        {
            src.PlayOneShot(playerLost);
        }
        awarenessRange.SetActive(true);
        awarenessLight.SetActive(false);
        chasingPlayer = false;
        return playerInRange = false;
    }

    public IEnumerator WaitAtPoint()
    {
        yield return new WaitForSeconds(2.5f);

        atPoint = false;
    }
}
