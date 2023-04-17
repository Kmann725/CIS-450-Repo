using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FacadePattern
{
    public class YouWinText : MonoBehaviour
    {


        void Start()
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }

        }

        public IEnumerator DisplayText()
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(5);
            gameObject.SetActive(false);
        }



    }
}