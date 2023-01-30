/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using UnityEngine;

namespace StrategyPatternWithScriptableObjects
{
    //Changed this class to extend ScriptableObject
    public abstract class ChangeColorBehavior : ScriptableObject
    {
        public abstract void ChangeColor(GameObject runner);
    }

}