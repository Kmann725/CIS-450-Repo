using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompositePatternSO
{
    public class Item : MonoBehaviour
    {
        //set these in the inspector
        public ItemComponentSO itemToPickup;
        public InventorySO inventory;
        public int amount;

        private void Start()
        {
            //Set the sprite of this gameObject to the sprite of the itemToPickup
            gameObject.GetComponent<Image>().sprite = itemToPickup.prefab.GetComponent<Image>().sprite;

            //Set the text of this gameObject to the amount of the item on this script
            gameObject.GetComponentInChildren<Text>().text = amount.ToString();
        }

        //A method to call with a button click UnityEvent
        //that adds the item to the inventory
        public void AddItem()
        {
            inventory.AddItem(itemToPickup, amount);
        }

        //Add item to inventory on 2d collision
    /*
        private void OnCollisionEnter2D(Collision2D collision)
        {
            inventory.AddItem(itemToPickup, amount);
        }
    */

        //Add item to inventory on 3d collision
    /*
        private void OnCollisionEnter(Collision collision)
        {
            inventory.AddItem(itemToPickup, amount);
        }
    */




    }
}