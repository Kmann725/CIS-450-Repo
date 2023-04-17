using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FacadePattern
{
    public class CoinManagerFacade : MonoBehaviour
    {
        //We can set public references in the inspector
        public TealCoin tealCoin;
        //Or we can set private references with code on Awake
        private OrangeCoin orangeCoin;
        //We can also set public references with code on Awake
        public YouWinText youWinText;

        private void Awake()
        {
            orangeCoin = GameObject.FindGameObjectWithTag("OrangeCoin").GetComponent<OrangeCoin>();
            youWinText = GameObject.FindGameObjectWithTag("YouWinText").GetComponent<YouWinText>();
        }

        // Facade provides a simplified interface to use subsystems without 
        // having to understand all of their details
        public void Win()
        {
            orangeCoin.PlaySoundEffect();

            StartCoroutine(youWinText.DisplayText());

            StartCoroutine(orangeCoin.SpinCoin());
            StartCoroutine(tealCoin.SpinCoin());

            StartCoroutine(orangeCoin.PlayParticleEffect());
            StartCoroutine(tealCoin.PlayParticleEffect());

        }

        public void DestroyCoins()
        {
            tealCoin.PlaySoundEffect();

            orangeCoin.MakeCoinDisappear();

            StartCoroutine(tealCoin.MakeCoinDisappear());
        }

    }
}