using System.Collections;
using UnityEngine;

namespace AdapterPattern
{
    //Using an abstract class rather than an interface so we can extend from MonoBehaviour
    public abstract class Triggerable: MonoBehaviour
    {
        public abstract void Trigger();

    }
}