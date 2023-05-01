//Iterator Design Pattern Example Code by Prof. Owen Schaffer, PhD

using System.Collections;
using UnityEngine;

namespace Assets.Week13_Iterator_Composite._1._Iterator_Pattern_with_IEnumerator
{
    [System.Serializable]
    //This Item class does not extend MonoBehaviour
    public class Item
    {
        //public enums show up as drop-down menus in the inspector
        public enum ItemType
        {
            Empty,
            HealthPotion,
            Bomb,
            Key,
        }

        public ItemType itemType;
        public int amount;
        public GameObject prefab;
        public string description;

    }
}