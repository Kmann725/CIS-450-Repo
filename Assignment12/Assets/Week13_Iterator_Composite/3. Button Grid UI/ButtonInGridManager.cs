using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInGridManager : MonoBehaviour
{
    //set this to the prefab to spawn in the inspector
    public GameObject buttonPrefab;
    public GameObject buttonPrefabWithSprite;

    //set this to the object that the spawned object will be a child of
    //in this case, the panel 
    public Transform panelParent;

    public Stack<GameObject> buttonsAdded = new Stack<GameObject>();
    
    public void Spawn()
    {
        GameObject spawnedButton = Instantiate(buttonPrefab, panelParent);
        buttonsAdded.Push(spawnedButton);
    }

    public void Remove()
    {
        if (buttonsAdded.Count > 0)
        {
            GameObject buttonToRemove = buttonsAdded.Pop();
            Destroy(buttonToRemove);
        }
    }

    public void SpawnWithSprite()
    {
        GameObject spawnedButton = Instantiate(buttonPrefabWithSprite, panelParent);
        buttonsAdded.Push(spawnedButton);
    }


}
