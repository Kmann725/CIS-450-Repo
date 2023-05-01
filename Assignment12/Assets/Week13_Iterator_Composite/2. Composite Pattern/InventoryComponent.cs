using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Week13_Iterator_Composite._2._Composite_Pattern
{
    public abstract class InventoryComponent : MonoBehaviour
    {
        //We can declare these in the abstract class so they are shared by subclasses
        //public enums show up as drop-down menus in the inspector
        public enum ItemType
        {
            Empty,
            HealthPotion,
            Bomb,
            Key,
            Sword,
            Backpack,
            Bag,
            Pouch,
            Inventory,
        }
        public ItemType itemType;
        public GameObject prefab;
        public string description;


        //Use abstract to force all subclasses to implement the method
        public abstract ItemType GetItemType();
        public abstract GameObject GetPrefab();
        public abstract void Print();

        //Use virtual to let subclasses either implement the method or use the default implementation given here
        //In this case, we only want Containers to use these, but we want to be able to use these when iterating
        //over all components.
        public virtual InventoryComponent GetChildItem(int i)
        {
            throw new System.NotSupportedException("GetChildItem() is not supported for " + this.GetType().Name);
        }
        public virtual void Add(InventoryComponent inventoryComponent)
        {
            throw new System.NotSupportedException("Add() is not supported for " + this.GetType().Name);
        }
        public virtual void Remove(InventoryComponent inventoryComponent)
        {
            throw new System.NotSupportedException("Remove() is not supported for " + this.GetType().Name);
        }

        //And let's say our containers will not have an amount because we don't want to stack them
        //So, only our ItemLeaf class will be able to GetAmount()
        public virtual int GetAmount()
        {
            throw new System.NotSupportedException("GetAmount() is not supported for " + this.GetType().Name);
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