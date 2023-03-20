using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

namespace CommandPatternWithNavMesh
{
    public class MoveObject : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;
     

        public void Awake()
        {
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

        }

        public Vector3 GetCurrentPosition()
        {
            return gameObject.transform.position;
        }


        public void MoveToPoint(Vector3 point)
        {
            Debug.Log(point);
            navMeshAgent.SetDestination(point);
        }



    }
}