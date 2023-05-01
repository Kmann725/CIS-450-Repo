//This code adapted from: https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT&index=1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompositePatternSO
{
    public enum ItemType
    {
        Default,
        Potion,
        Consumable,
        Equipment,
        Bomb,
        Key,
        Container,
    }

    public abstract class ItemComponentSO : ScriptableObject
    {
        public GameObject prefab;
        public ItemType type;
        [TextArea(15, 20)]
        public string description;

        public abstract void SpawnAllItemsInGrid(ItemComponentSO itemToAdd, Transform panelParent, Stack<GameObject> prefabsAdded);

    }
}
