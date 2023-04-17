using System.Collections;
using UnityEngine;

namespace Assets.Works_In_Progress.Week12__1._Adapter_Pattern_with_GameObjects.Scripts
{
    public class TriggerZone : MonoBehaviour
    {
        

        // Use this for initialization
        void Start()
        {

        }

        void OnTriggerEnter2D(Collider2D theCollider)
        {
            if (theCollider.CompareTag("Player"))
            {
                //TriggerEffect();
            }
        }


    }
}