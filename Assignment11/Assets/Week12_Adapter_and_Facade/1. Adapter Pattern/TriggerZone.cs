using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdapterPattern
{
    public class TriggerZone : MonoBehaviour
    {
        //set this in the inspector
        public Triggerable triggerable;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                triggerable.Trigger();
            }
        }

    }
}