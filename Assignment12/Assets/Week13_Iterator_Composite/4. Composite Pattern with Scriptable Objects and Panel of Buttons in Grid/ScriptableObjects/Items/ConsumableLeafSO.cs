//This code adapted from: https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT&index=1
using System.Collections;
using UnityEngine;

namespace CompositePatternSO
{
    [CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory System/Items/Consumable")]
    public class ConsumableLeafSO : DefaultItemLeafSO
    {
        public int healthRestoreAmount;
        public int manaRestoreAmount;
        public int staminaRestoreAmount;

        private void Awake()
        {
            type = ItemType.Consumable;
        }
    }
}