using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace TemplateMethodPatternConsole
{
    public class NPCTestDriveMain : MonoBehaviour
    {
        Ally ally;
        Enemy enemy;

        //To review coroutines see https://github.com/thesecretlab/unity-game-development-cookbook-1e/blob/master/Scripting/Assets/Coroutines.cs


        // Start can be a coroutine. 
        // Just set its return type to IEnumerator.
        IEnumerator Start()
        {
            ally = new Ally();
            enemy = new Enemy();

            while (true)
            {

                ally.Interact();

                //This adds a 1 second pause
                yield return new WaitForSeconds(1);

                enemy.Interact();
                yield return new WaitForSeconds(5);
            }
        }

        // Update is called once per frame
        void Update()
        {
            //This sets the enemy Aggro bool to true or false
            //when the player presses the 1 or 2 keys on the keyboard
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                enemy.Aggro = false;
                Debug.Log("Enemy no longer wants to attack you.");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                enemy.Aggro = true;
                Debug.Log("Enemy is now aggressive towards you, ready to attack.");
            }

        }
    }
}