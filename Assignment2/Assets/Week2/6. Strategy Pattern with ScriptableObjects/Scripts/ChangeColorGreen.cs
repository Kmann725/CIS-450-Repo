/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using UnityEngine;


namespace StrategyPatternWithScriptableObjects
{
    [CreateAssetMenu]
    public class ChangeColorGreen : ChangeColorBehavior
    {
        public override void ChangeColor(GameObject runner)
        {
            Debug.Log("Color Change green");
            runner.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;

        }
    }

}