//This code adapted from: https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT&index=1
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompositePatternSO
{
    [CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
    public class EquipmentLeafSO : DefaultItemLeafSO
    {
        public float atkBonus;
        public float defBonus;

        private void Awake()
        {
            type = ItemType.Equipment;
        }
    }
}