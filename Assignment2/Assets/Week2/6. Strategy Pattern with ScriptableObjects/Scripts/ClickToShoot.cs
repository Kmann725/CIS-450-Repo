﻿/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPatternWithScriptableObjects
{

    //This must be attached to the main camera
    //This allows the player to click to call the Die() method on Enemies
    public class ClickToShoot : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            //Part 1: Killing any Enemy on LMB click
            if (Input.GetMouseButtonDown(0))
            {
                Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(rayOrigin, out hitInfo))
                {               
                    //we can pass in super-types like super-classes,
                    //abstract classes, and interfaces to GetComponent<SupertypeName>()
                    IDestroyable objectHit = hitInfo.collider.GetComponent<IDestroyable>();  //here we pass in an interface

                    if (objectHit != null)
                    {
                        //Calls the Die() method on the hit Enemy object
                        objectHit.Die();
                    }
                }
            }

            //Part 2: Using Strategy Pattern to Choose a Color to Paint Objects On RMB Click
            if (Input.GetMouseButtonDown(1))
            {
                Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(rayOrigin, out hitInfo))
                {
                    //we can pass in super-types like super-classes,
                    //abstract classes, and interfaces to GetComponent<SupertypeName>()
                    Enemy objectHit = hitInfo.collider.GetComponent<Enemy>();  //here we pass in the abstract parent class

                    if (objectHit != null)
                    {
                        //This is the only line that is different from Part 1 above
                        //This calls the DoChangeColor() method on the hit object
                        objectHit.DoChangeColor();

                    }
                }
            }


        }
    }
}
 