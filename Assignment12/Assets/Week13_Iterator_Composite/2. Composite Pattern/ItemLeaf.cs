using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Week13_Iterator_Composite._2._Composite_Pattern
{
    public class ItemLeaf : InventoryComponent
    {

        public int amount;

        //public ItemType itemType;
        //public GameObject prefab;
        //public string description;

        public override int GetAmount()
        {
            return amount;
        }

        public override ItemType GetItemType()
        {
            return itemType;
        }

        public override GameObject GetPrefab()
        {
            return prefab;
        }

        public override void Print()
        {
            //print item amount and name (set up as an ItemType enum)
            Debug.Log(GetAmount() + " " + GetItemType());

            if (!string.IsNullOrEmpty(description)) 
            { 
                Debug.Log(description); 
            }
        }



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}