using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AdapterPattern
{
    //Attach this class to a UI text object to display the text
    public class DisplayText : MonoBehaviour
    {
        private string textToDisplay;

        void Start()
        {
            textToDisplay = gameObject.GetComponent<Text>().text;
        }

        public void Display(string text)
        {
            transform.parent.gameObject.SetActive(true);
            textToDisplay = text;
            gameObject.GetComponent<Text>().text = this.textToDisplay;
        }


    }
}