using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPatternWithNavMesh
{
    public class PlayerInputManagerInvoker : MonoBehaviour
    {
        public MoveObject moveObject;
        private Command moveToPoint;

        //Note that this is not using the stack or dictionary of commands - you may need to implement those
        //private List<Command> commandHistory;

        // Use this for initialization
        void Start()
        {
            //creating the instance of the MoveToPoint command and passing in the receiver to its constructor
            moveToPoint = new MoveToPoint(moveObject);

            //commandHistory = new List<Command>();



        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {

                    //instead of this...
                    //agent.SetDestination(hit.point);

                    //call execute on our command class
                    moveToPoint.Execute(hit.point);


                }


            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                moveToPoint.Undo();
            }

        }

    }
}