using UnityEngine;
using System.Collections;

namespace TemplateMethodPatternConsole
{
    public class Ally : NPC
    {
        private bool Aggro = false;

        public override void Speak()
        {
            Debug.Log("The " + GetType() + " greets you with a smile.");
        }

        public override bool IsAggro()
        {
            //Add some logic here that would 
            //change the Aggro bool based on player action

            return Aggro;

        }

        public override void Attack()
        {
            Debug.Log("The " + GetType() + " attacks you.");
        }


    }
}