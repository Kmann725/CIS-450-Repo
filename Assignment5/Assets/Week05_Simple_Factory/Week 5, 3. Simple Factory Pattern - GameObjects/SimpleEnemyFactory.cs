using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleFactoryPatternWithGameObjects
{

    //Attach this class to an empty GameObject
    public class SimpleEnemyFactory : MonoBehaviour
    {
        public GameObject VampirePrefab;
        public GameObject WerewolfPrefab;
        public GameObject ZombiePrefab;

        private GameObject enemyToSpawn;

        public GameObject CreateEnemy(string type)
        {
            enemyToSpawn = null;

            if (type.Equals("Zombie"))
            {
                enemyToSpawn = ZombiePrefab;
            }
            else if (type.Equals("Vampire"))
            {
                enemyToSpawn = VampirePrefab;
            }
            else if (type.Equals("Werewolf"))
            {
                enemyToSpawn = WerewolfPrefab;
            }

            Debug.Log("Factory sending: " + enemyToSpawn);
            return enemyToSpawn;
        }

    }
}