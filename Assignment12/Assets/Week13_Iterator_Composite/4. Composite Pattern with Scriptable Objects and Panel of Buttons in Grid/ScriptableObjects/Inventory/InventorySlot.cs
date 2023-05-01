//This code adapted from: https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT&index=1
using System.Collections;
using UnityEngine;

namespace CompositePatternSO
{
    //This class does not extend MonoBehaviour 
    //and it is serializble so it shows up in the inspector
    [System.Serializable]
    public class InventorySlot
    {
        public ItemComponentSO item;
        public int amount;
        
        //We can use constructors with classes that do not extend MonoBehaviour
        public InventorySlot(ItemComponentSO item, int amount)
        {
            this.item = item;
            this.amount = amount;
        }

        public void AddAmount(int amount)
        {
            this.amount += amount;
        }

    }
}