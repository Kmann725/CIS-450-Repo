using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Week13_Iterator_Composite._2._Composite_Pattern
{
    public class ContainerComposite : InventoryComponent
    {
        //This list of InventoryComponents holds the items (and containers) in this container
        public List<InventoryComponent> inventoryComponents = new List<InventoryComponent>();

        //Because we are using the Composite Pattern, 
        //both items and containers are InventoryComponents and containers hold InventoryComponents

        //This means we can treat bags as just another item and have bags within bags!

        //These are declared in the abstract superclass, so they are commented-out here (& could be deleted):
        //public ItemType itemType;
        //public GameObject prefab;
        //public string description;

        //Getters
        public override ItemType GetItemType()
        {
            return itemType;
        }
        public override GameObject GetPrefab()
        {
            return prefab;
        }

        //We can use the iterator pattern to iterate through the List of components
        public override void Print()
        {
            //Debug.Log("Printing a container called " + GetItemType());

            //Print the item name (ItemType) and description (if it has one)
            Debug.Log(GetItemType());
            if (!string.IsNullOrEmpty(description))
            {
                Debug.Log(description);
            }

            Debug.Log("-----Contents of " + GetItemType() + "-----");

            //Call Print() on all components in the List of componenets (recursive)
            //We can use foreach right here
/*
            foreach (InventoryComponent inventoryComponent in inventoryComponents)
            {
                //Debug.Log("Printing a component called " + inventoryComponent.GetItemType());
                inventoryComponent.Print();
            }
*/

            //Or we can extract this foreach loop out as its own reusable method
            //IterateWithForEach(inventoryComponents);

            //Or we can use IEnumerator to iterate through the items
            //This gives us more control over how we iterate through the items
            IterateWithIEnumerator(inventoryComponents);

            Debug.Log("---End of Contents of " + GetItemType() + "---");

        }

        //Iterator methods - we can use the iterator pattern with the composite pattern
        //This first one uses foreach and yield return
        private void IterateWithForEach (List<InventoryComponent> inventoryComponents)
        {
            foreach (InventoryComponent inventoryComponent in inventoryComponents)
            {
                inventoryComponent.Print();
            }
        }
        //This second one uses IEnumerator to iterate through the components
        //This does the same thing as the first iterator method above, but gives you more control
        //The IEnumerator<> class implements the Iterator desin pattern for us
        private void IterateWithIEnumerator(IEnumerable<InventoryComponent> inventoryComponents)
        {
            //Get the Enumerator
            IEnumerator<InventoryComponent> enumerator = inventoryComponents.GetEnumerator();
            
            //Enumerator starts at index -1
            //while there's still a next item, go to the next position
            while ( enumerator.MoveNext() )
            {
                //get the current componenet the enumerator is pointing to
                InventoryComponent component = enumerator.Current;
                
                //call print on that component
                component.Print();
            }

        }



        //Container methods
        public override InventoryComponent GetChildItem(int i)
        {
            return inventoryComponents[i];
        }
        public override void Add(InventoryComponent inventoryComponent)
        {
            inventoryComponents.Add(inventoryComponent);
        }
        public override void Remove(InventoryComponent inventoryComponent)
        {
            inventoryComponents.Remove(inventoryComponent);
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