using System.Collections;
using UnityEngine;

namespace Assets.Week13_Iterator_Composite._2._Composite_Pattern
{
    public class InventoryTestDrive : MonoBehaviour
    {
        //Can set this in the inspector
        public ContainerComposite inventory;

        // Use this for initialization
        void Start()
        {
            inventory.Print();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}