using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPatternWithNavMesh
{
    public class MoveToPoint : Command
    {
        MoveObject moveObject;

        Stack<Vector3> positionHistory;

        public MoveToPoint(MoveObject moveObject)
        {
            this.moveObject = moveObject;
            positionHistory = new Stack<Vector3>();
        }

        public void Execute(Vector3 point)
        {
            positionHistory.Push(moveObject.GetCurrentPosition());

            moveObject.MoveToPoint(point);

        }

        public void Undo()
        {


            //Instead, we will assign the Vector3 position in our stack to our gameObject
            if (positionHistory.Count != 0)
            {
                moveObject.MoveToPoint(positionHistory.Pop());
            }
            
        }


    }

}