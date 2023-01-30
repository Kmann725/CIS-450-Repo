/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using UnityEngine;


namespace StrategyPatternWithScriptableObjects
{
    [CreateAssetMenu]
    public class ChangeColorBlue : ChangeColorBehavior
    {
        public override void ChangeColor(GameObject runner)
        {
            Debug.Log("Color Change blue");
            runner.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;

        }
    }

}