using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPatternWithNavMesh
{

    public interface Command
    {
        void Execute(Vector3 point);
        void Undo();
    }

}