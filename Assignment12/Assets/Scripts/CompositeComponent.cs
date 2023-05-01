/*
 * Kyle Manning
 * CompositeComponent.cs
 * Assignment 12
 * Composite object for the pattern; stores a list of items and has methods
 * for unpacking the lists
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeComponent : Item
{
    public List<Item> chestItems = new List<Item>();

    public override void UnpackContainer()
    {
        if (gameObject.GetComponent<Item>().item == ItemType.BigChest)
        {
            StartGlow();
        }

        foreach(Item item in chestItems)
        {
            Item newItem = item.SpawnItem();

            newItem.StartGlow();
        }

        chestItems.Clear();
    }

    public override void UnpackCompletely()
    {
        if (gameObject.GetComponent<Item>().item == ItemType.BigChest)
        {
            StartGlow();
        }

        foreach (Item item in chestItems)
        {
            Item newItem = item.SpawnItem();
            
            if (newItem.item == ItemType.LittleChest)
            {
                newItem.UnpackCompletely();
            }

            newItem.StartGlow();
        }

        chestItems.Clear();
    }

    public override void StartGlow()
    {
        StartCoroutine(Glowing());
    }

    IEnumerator Glowing()
    {
        while (true)
        {
            for (int i = 1; i <= 70; i++)
            {
                glow.intensity = 0.1f * i;
                yield return new WaitForSeconds(0.05f);
            }

            for (int i = 1; i <= 70; i++)
            {
                glow.intensity = 7 - (0.1f * i);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
