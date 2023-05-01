/*
 * Kyle Manning
 * Item.cs
 * Assignment 12
 * Abstract class used for the composite and leaf objects; has a concrete method for
 * spawning objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public enum ItemType
    {
        BigChest,
        LittleChest,
        GoldCoin,
        SilverCoin,
        Pearl,
        Key
    }

    public ItemType item;
    public GameObject prefab;
    public Light glow;

    public virtual void UnpackContainer()
    {
        throw new System.NotSupportedException("UnpackContainer() is not supported for " + this.GetType().Name);
    }

    public virtual void UnpackCompletely()
    {
        throw new System.NotSupportedException("UnpackCompletely() is not supported for " + this.GetType().Name);
    }

    public virtual void StartGlow()
    {
        throw new System.NotSupportedException("StartGlow() is not supported for " + this.GetType().Name);
    }

    public Item SpawnItem()
    {
        return Instantiate(prefab, transform.position, transform.rotation).GetComponent<Item>();
    }
}
