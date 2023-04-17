using UnityEngine;
using System.Collections;

namespace FacadePattern
{
    [RequireComponent(typeof(AudioSource))]
    public class OrangeCoin : MonoBehaviour
    {
        public AudioClip coinPickup2;
        AudioSource audioSource;

        public ParticleSystem particleEffect;

        [Range(1.0f, 5.0f)]
        public float rotateSpeed = 1.0f;


        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public IEnumerator SpinCoin()
        {
            //to rotate smootly a bit on each frame
            while (this != null)
            {

                transform.Rotate(transform.up, 360 * rotateSpeed * Time.deltaTime);

                // to avoid an infinite loop
                yield return 0;

            }
        }


        public IEnumerator PlayParticleEffect()
        {
            particleEffect.Play();
            yield return new WaitForSeconds(5);
            particleEffect.Stop();
        }

        public void PlaySoundEffect()
        {
            audioSource.PlayOneShot(coinPickup2);
        }

        public void MakeCoinDisappear()
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }

    }
}