/*
 * Kyle Manning
 * Assignment 10
 * BoardPooler.cs
 * Singleton which stores object pools and can spawn and return objects to pools
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPooler : MonoBehaviour
{
    private AudioSource src;

    public List<Pool> pool;

    public Dictionary<string, Queue<GameObject>> poolDic;

    public AudioClip despawning;

    public static BoardPooler instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static BoardPooler GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        src = GetComponent<AudioSource>();

        poolDic = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pool)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.board);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDic.Add(pool.tag, objectPool);
        }
    }

    public void SpawnObject(string tag, GameObject spawnPos)
    {
        GameObject poolObj = poolDic[tag].Dequeue();

        poolObj.SetActive(true);
        poolObj.transform.position = spawnPos.transform.position;
        poolObj.transform.rotation = spawnPos.transform.rotation;
    }

    public void ReturnObject(string tag, GameObject objectToReturn)
    {
        src.PlayOneShot(despawning);

        objectToReturn.SetActive(false);

        poolDic[tag].Enqueue(objectToReturn);
    }
}
