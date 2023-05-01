//This code adapted from: https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT&index=1
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompositePatternSO
{
    [CreateAssetMenu(fileName ="New Inventory", menuName = "Inventory System/Inventory")]
    public class InventorySO : ScriptableObject
    {
        public List<InventorySlot> inventory = new List<InventorySlot>();
        
        public void AddItem(ItemComponentSO itemToAdd, int amountToAdd)
        {
            //Check if item is already in the inventory
            bool inventoryHasItem = false;

            //for each inventor slot
            foreach (InventorySlot inventorySlot in inventory)
            {
                //if the item being added is in the inventory
                if (inventorySlot.item.Equals(itemToAdd))
                {
                    //then add the amount being added to its inventory slot
                    inventorySlot.AddAmount(amountToAdd);
                    //set inventoryHasItem to true
                    inventoryHasItem = true;
                    //and break out of the foreach loop
                    break;
                }
            }

            if (!inventoryHasItem)
            {
                inventory.Add(new InventorySlot(itemToAdd, amountToAdd));
            }

        }


    }



}