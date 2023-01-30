/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using UnityEngine;


namespace StrategyPatternWithScriptableObjects
{
    [CreateAssetMenu]
    public class ChangeColorRed : ChangeColorBehavior
    {
        public override void ChangeColor(GameObject runner)
        {
            Debug.Log("Color Change red");
            runner.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

        }
    }

}