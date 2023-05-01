using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Week13_Iterator_Composite._1._Iterator_Pattern_with_IEnumerator
{
    public class InventoryTestDrive : MonoBehaviour
    {
        //Can get references through GameObjects
        public GameObject itemArrayGO;
        public GameObject itemListGO;
        public GameObject itemDictionaryGO;

        private Item[] itemArray;
        private List<Item> itemList;
        private Dictionary<string, Item> itemDictionary;


        private void Awake()
        {
            itemArray = itemArrayGO.GetComponent<Array>().items;
            itemList = itemListGO.GetComponent<List>().items;
            itemDictionary = itemDictionaryGO.GetComponent<Dictionary>().itemDictionary;   
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Call methods on an array with 1,2,3
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Calling PrintAllItemsInArray() on array");
                PrintAllItemsInArray(itemArray);
            }

            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Calling PrintAllItemsInEnumerable() on array");
                PrintAllItemsInEnumerable(itemArray);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("Calling PrintAllItemsWithEnumerator() on array");
                PrintAllItemsWithEnumerator(itemArray);
            }

            // Call methods on a List with Q,W,E
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Calling PrintAllItemsInArray() on List");
                PrintAllItemsInList(itemList);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Calling PrintAllItemsInEnumerable() on List");
                PrintAllItemsInEnumerable(itemList);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Calling PrintAllItemsWithEnumerator() on List");
                PrintAllItemsWithEnumerator(itemList);
            }

            //Call methods on a Dictionary with A,S,D
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Calling PrintAllItemsInArray() on Dictionary.Values");
                PrintAllItemsInDictionaryValues(itemDictionary);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Calling PrintAllItemsInEnumerable() on Dictionary.Values");
                //Notice we pass in just the Values of the dictionary with .Values to get the items
                PrintAllItemsInEnumerable(itemDictionary.Values);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Calling PrintAllItemsWithEnumerator() on Dictionary.Values");
                //Notice we pass in just the Values of the dictionary with .Values to get the items
                PrintAllItemsWithEnumerator(itemDictionary.Values);
            }

        }

        //If we specify the specific type of the collection, we need separate methods
        private void PrintAllItemsInArray(Item[] arrayOfItems)
        {
            foreach (Item item in arrayOfItems)
            {
                Debug.Log(item.itemType);
            }
        }

        private void PrintAllItemsInList(List<Item> listOfItems)
        {
            foreach (Item item in listOfItems)
            {
                Debug.Log(item.itemType);
            }
        }

        private void PrintAllItemsInDictionaryValues(Dictionary<string,Item> dictionaryOfItems)
        {
            //Notice we foreach over the .Values of the dictionary to get the items not the string
            foreach (Item item in dictionaryOfItems.Values)
            {
                Debug.Log(item.itemType);
            }
        }

        //We can use either of the following two methods on all of the collections
        //This first one uses foreach
        private void PrintAllItemsInEnumerable(IEnumerable<Item> enumerable)
        {
            foreach (Item item in enumerable)
            {
                Debug.Log(item.itemType);
            }
        }
        //This method uses an Enumerator
        private void PrintAllItemsWithEnumerator(IEnumerable<Item> enumerable)
        {
            //Part 1
            //This first part does the same thing as 
            //the foreach loop in the method above
            
            //Get the Enumerator
            IEnumerator<Item> enumerator = enumerable.GetEnumerator();
            
            //while there is a next thing to enumerate or iterate over...
            while (enumerator.MoveNext())
            {
                //...get the current item and print its type
                Debug.Log(enumerator.Current.itemType);
            }

            //Part 2
            //This is a more complete and precise version of what a foreach loop does when compiled
            //For more on this, see https://www.youtube.com/watch?v=NUWwRwtWh0Q&list=PLRwVmtr-pp07QlmssL4igw1rnrttJXerL&index=15
            /*IEnumerator<Item> itemEnumerator = enumerable.GetEnumerator();
            try
            {
                while (itemEnumerator.MoveNext())
                {
                    Item item = itemEnumerator.Current;
                    Debug.Log(item.itemType);
                }
            }
            finally
            {
                itemEnumerator.Dispose();
            }*/

            //Part 3
            //But an Enumerator gives us more control, letting us do things
            //that would not be possible with a foreach loop
            Debug.Log("Using an Enumerator gives us more control over iteration.");
            enumerator.Reset();
            // Enumerator.Current starts at index position -1, so this 
            // code throws an InvalidOperationException:
            /*Debug.Log("Enumerator.Current starts at index position -1: " 
                + enumerator.Current.itemType);*/
            enumerator.MoveNext();
            Debug.Log("First item: " + enumerator.Current.itemType);
            enumerator.MoveNext();
            enumerator.MoveNext();
            Debug.Log("Third item: " + enumerator.Current.itemType);

        }


    }
}