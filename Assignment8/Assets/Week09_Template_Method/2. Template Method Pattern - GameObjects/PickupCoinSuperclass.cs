using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PickupCoinSuperclass : MonoBehaviour
{
    protected static bool isFirstCoinPickup = true;
    protected bool triggered = false;
    protected static bool soundEffectsOn = true;

    float rotateSpeed = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !triggered)
        {
            PickupCoin();
            triggered = true;
        }
    }

    public void PickupCoin()
    {
        if (IsFirstCoinPickup())
        {
            StartCoroutine(ShowTutorialText());
            isFirstCoinPickup = false;
        }

        StartCoroutine(SpinCoin());

        StartCoroutine(PlayParticleEffect());

        if (AreSoundEffectsOn())
        {
            PlaySoundEffect();
        }

        StartCoroutine(MakeCoinDisappear());



    }

    protected virtual bool IsFirstCoinPickup()
    {
        return isFirstCoinPickup;
    }

    public abstract IEnumerator ShowTutorialText();

    protected IEnumerator SpinCoin()
    {
        //to rotate smootly a bit on each frame
        while (true)
        {

            transform.Rotate(transform.up, 360 * rotateSpeed * Time.deltaTime);

            // to avoid an infinite loop
            yield return 0;

        }
    }

    public abstract IEnumerator PlayParticleEffect();

    public virtual bool AreSoundEffectsOn()
    {
        return soundEffectsOn;
    }

    public abstract void PlaySoundEffect();

    public virtual IEnumerator MakeCoinDisappear()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }


}