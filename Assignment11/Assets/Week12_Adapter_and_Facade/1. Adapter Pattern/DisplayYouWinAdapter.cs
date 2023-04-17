using System.Collections;
using UnityEngine;

namespace AdapterPattern
{
    public class DisplayYouWinAdapter : Triggerable
    {
        //Can set this in the inspector
        public DisplayText displayText;

        //This method implements the target interface, Triggerable
        public override void Trigger()
        {
            //this calls the Display method on displayText, passing in some text
            displayText.Display("You Win!");
        }

    }
}