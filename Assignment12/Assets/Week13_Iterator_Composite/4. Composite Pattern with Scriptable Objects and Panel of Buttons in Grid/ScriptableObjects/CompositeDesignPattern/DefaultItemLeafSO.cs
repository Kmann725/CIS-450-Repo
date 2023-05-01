//This code adapted from: https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT&index=1
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompositePatternSO
{
    [CreateAssetMenu(fileName = "New Default Object", menuName ="Inventory System/Items/Default")]
    public class DefaultItemLeafSO : ItemComponentSO
    {
        private void Awake()
        {
            type = ItemType.Default;
        }

        public override void SpawnAllItemsInGrid(ItemComponentSO itemToAdd, Transform panelParent, Stack<GameObject> prefabsAdded)
        {
            GameObject spawnedButton = Instantiate(itemToAdd.prefab, panelParent);
            prefabsAdded.Push(spawnedButton);
        }

    }
}