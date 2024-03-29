﻿/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPatternWithScriptableObjects
{


    public class EnemySpider : Enemy, IDestroyable
    {
        //Now that Enemy extends Monobehavior,
        //it is better to use Awake() than a constructor
        public void Awake()
        {
            //And we use gameObject.AddComponent<ChangeColorBlue>(); instead of new
            //to add the ChageColorBlue script/class to the EnemySpider on Awake()
            ChangeColorBehavior = ScriptableObject.CreateInstance<ChangeColorBlue>(); 

        }



        public override void Die()
        {
            Debug.Log("The spider dies.");
            //add death animations and particle effects for spider death here
            Destroy(gameObject);
        }

        

    }
}