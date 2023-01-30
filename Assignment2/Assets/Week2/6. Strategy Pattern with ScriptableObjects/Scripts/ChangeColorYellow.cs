/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StrategyPatternWithScriptableObjects
{
    [CreateAssetMenu]
    public class ChangeColorYellow : ChangeColorBehavior
    {
        public override void ChangeColor(GameObject runner)
        {
            Debug.Log("Color Change yellow");
            runner.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;

        }
    }

}