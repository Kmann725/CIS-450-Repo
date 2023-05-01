//This code adapted from: https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT&index=1
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace CompositePatternSO
{
    [CreateAssetMenu(fileName = "New Container Object", menuName = "Inventory System/Containers/Default")]
    public class DefaultContainerCompositeSO : ItemComponentSO
    {
        public List<ItemComponentSO> components = new List<ItemComponentSO>();

        private void Awake()
        {
            type = ItemType.Container;
        }

        public override void SpawnAllItemsInGrid(ItemComponentSO itemToAdd, Transform panelParent, Stack<GameObject> prefabsAdded)
        {
            //spawn the container as if it were any item
            GameObject spawnedButton = Instantiate(itemToAdd.prefab, panelParent);
            prefabsAdded.Push(spawnedButton);

            //then for each component within in this composite... 
            foreach (ItemComponentSO itemComponent in components)
            {
                //call this method on each of those componenets - this is recursion
                itemComponent.SpawnAllItemsInGrid(itemComponent, panelParent, prefabsAdded);
            }
        }

    }
}