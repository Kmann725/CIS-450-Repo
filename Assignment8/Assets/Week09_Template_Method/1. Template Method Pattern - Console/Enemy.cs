using UnityEngine;
using System.Collections;

namespace TemplateMethodPatternConsole
{
    public class Enemy : NPC
    {
        public bool Aggro = false;

        public override void Speak()
        {
            Debug.Log("The " + GetType() + " snarls at you.");
        }

        public override bool IsAggro()
        {
            //We could add some logic here that would 
            //change the Aggro bool based on player action.
            
            //In this example, the Aggro bool is set in the
            //Update method of NPCTestDriveMain.cs when the player
            //presses the 1 or 2 keys on the keyboard.
            
            //So, this just returns the Boolean variable:
            return Aggro;
        }

        public override void Attack()
        {
            Debug.Log("The " + GetType() + " attacks you.");
        }
    }
}