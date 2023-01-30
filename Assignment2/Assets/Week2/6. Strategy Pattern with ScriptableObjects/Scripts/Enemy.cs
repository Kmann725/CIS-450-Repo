/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPatternWithScriptableObjects
{

    public abstract class Enemy: MonoBehaviour
    {

        public ChangeColorBehavior ChangeColorBehavior;


        //Performs the color change behavior. Virtual means this method can be overridden by a subclass.
        public virtual void DoChangeColor() { ChangeColorBehavior.ChangeColor(this.gameObject); }


        //abstract methods must be implemented by concrete sub-classes
        public abstract void Die();

        //Unlike interfaces, abstract classes can have concrete methods
        //These concrete methods are inherited by sub-classes
        public void speak() { Debug.Log("I'm an enemy. Fear me!"); }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DoChangeColor();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //Destroy(GetComponent<ChangeColorBehavior>());
                ChangeColorBehavior = ScriptableObject.CreateInstance<ChangeColorRed>();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //Destroy(GetComponent<ChangeColorBehavior>());
                ChangeColorBehavior = ScriptableObject.CreateInstance<ChangeColorBlue>();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                //Destroy(GetComponent<ChangeColorBehavior>());
                ChangeColorBehavior = ScriptableObject.CreateInstance<ChangeColorGreen>();
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                //Destroy(GetComponent<ChangeColorBehavior>());
                ChangeColorBehavior = ScriptableObject.CreateInstance<ChangeColorYellow>();
            }

        }


    }

}