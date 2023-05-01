using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompositePatternSO
{
    public class UIManager : MonoBehaviour
    {
        //set this to the object that the spawned object will be a child of
        //in this case, the panel 
        public Transform panelParent;

        public InventorySO inventorySO;

        //Stack to hold buttons added
        public Stack<GameObject> prefabsAdded = new Stack<GameObject>();

        public void SpawnAllInventoryItems()
        {

            foreach (InventorySlot inventorySlot in inventorySO.inventory)
            {
                ItemComponentSO itemToAdd = inventorySlot.item;
                if (itemToAdd != null)
                {

                    //We replace these two lines of code:
                    //GameObject spawnedButton = Instantiate(itemToAdd.prefab, panelParent);
                    //buttonsAdded.Push(spawnedButton);

                    //...with this code that takes the dependencies it needs as arguments
                    //and then does the same thing within each component.
                    //Item Leaf does this once for its item and Container Composite 
                    //calls this method on each of its componenets recursively.
                    itemToAdd.SpawnAllItemsInGrid(itemToAdd, panelParent, prefabsAdded);
                }
            }

        }

        public void Remove()
        {
            if (prefabsAdded.Count > 0)
            {
                GameObject buttonToRemove = prefabsAdded.Pop();
                Destroy(buttonToRemove);
            }
        }



    }
}