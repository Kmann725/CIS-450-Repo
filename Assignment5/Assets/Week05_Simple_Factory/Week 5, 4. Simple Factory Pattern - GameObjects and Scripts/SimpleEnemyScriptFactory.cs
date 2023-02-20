using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleFactoryPatternWithGameObjectsAndScripts
{

    //Attach this class to an empty GameObject
    public class SimpleEnemyScriptFactory : MonoBehaviour
    {

        private GameObject enemyToSpawn;

        public GameObject AddEnemyScript(GameObject prefab, string type)
        {
            enemyToSpawn = prefab;

            if (type.Equals("Zombie"))
            {

                //If there is not already a Zombie script attached, attach one
                if (enemyToSpawn.GetComponent<Zombie>() == null)
                {
                    enemyToSpawn.AddComponent<Zombie>();
                }
            }
            else if (type.Equals("Vampire"))
            {

                //If there is not already a Vampire script attached, attach one
                if (enemyToSpawn.GetComponent<Vampire>() == null)
                {
                    enemyToSpawn.AddComponent<Vampire>();
                }

            }
            else if (type.Equals("Werewolf"))
            {

                //If there is not already a Werewolf script attached, attach one
                if (enemyToSpawn.GetComponent<Werewolf>() == null)
                {
                    enemyToSpawn.AddComponent<Werewolf>();
                }

            }

            Debug.Log("Factory sending: " + enemyToSpawn);
            return enemyToSpawn;
        }

    }
}