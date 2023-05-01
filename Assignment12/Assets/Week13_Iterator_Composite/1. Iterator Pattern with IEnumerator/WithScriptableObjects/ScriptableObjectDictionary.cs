using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Week13_Iterator_Composite._1._Iterator_Pattern_with_IEnumerator
{
    [CreateAssetMenu]
    public class ScriptableObjectDictionary : ScriptableObject, ISerializationCallbackReceiver
    {
        public Dictionary<string, Item> itemDictionary;


        public int dictionarySize = 5;

        #region Show Dictionaries in Inspector
        //---------------------------------------------------------------
        //This code and the ISerializationCallbackReceiver interface 
        //implemented above just make dictionaries show in the inspector
        //The code below is adapted from https://docs.unity3d.com/ScriptReference/ISerializationCallbackReceiver.html
        //---------------------------------------------------------------
        public List<string> keys = new List<string>() { string.Empty, string.Empty, string.Empty };
        public List<Item> values = new List<Item>() { new Item(), new Item(), new Item() };
        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();

            foreach (var kvp in itemDictionary)
            {
                keys.Add(kvp.Key);
                values.Add(kvp.Value);
            }

            while (keys.Count < dictionarySize)
            {
                for (int i = 0; i < (dictionarySize - keys.Count); i++)
                {
                    //If our key is an int, we can use:
                    //keys.Add(keys.Count + i);

                    //using .ToString() on the int for the key:
                    keys.Add((keys.Count + i).ToString());
                }
            }
            while (values.Count < dictionarySize)
                values.Add(new Item());
            while (keys.Count > dictionarySize)
                keys.RemoveAt(keys.Count - 1);
            while (values.Count > dictionarySize)
                values.RemoveAt(values.Count - 1);
        }

        public void OnAfterDeserialize()
        {
            itemDictionary = new Dictionary<string, Item>();

            if (dictionarySize < 0) dictionarySize = 0;

            if (dictionarySize > 0)
            {
                for (int i = 0; i != Math.Min(keys.Count, values.Count); i++)
                    itemDictionary.Add(keys[i], values[i]);
            }
        }

        void OnGUI()
        {
            foreach (var kvp in itemDictionary)
                GUILayout.Label("Key: " + kvp.Key + " value: " + kvp.Value);
        }
        #endregion


    }
}