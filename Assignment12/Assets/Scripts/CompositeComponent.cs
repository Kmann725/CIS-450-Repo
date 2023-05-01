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
        foreach(Item item in chestItems)
        {
            Item newItem = item.SpawnItem();

            if (newItem.item != ItemType.LittleChest)
            {
                newItem.StartGlow();
            }
        }

        chestItems.Clear();
    }

    public override void UnpackCompletely()
    {
        foreach (Item item in chestItems)
        {
            Item newItem = item.SpawnItem();
            
            if (newItem.item == ItemType.LittleChest)
            {
                newItem.UnpackCompletely();
            }

            if (newItem.item != ItemType.LittleChest)
            {
                newItem.StartGlow();
            }
        }

        chestItems.Clear();
    }
}
