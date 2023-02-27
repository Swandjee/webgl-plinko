using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class SoundManager : MonoBehaviour
    {
        public AudioClip[] basketTouched;
        public AudioClip[] endJingle;
		public AudioSource audioSource;
        public static SoundManager Instance
        {
            get;
            private set;
        }

		private void Awake()
		{
			if (Instance != null && Instance != this)
			{
				Destroy(this);
				return;
			}
			Instance = this;
		}
		private void PlayRandomSound(AudioClip[] clips)
		{
			var randomClipIndex = Random.Range(0, clips.Length);
			var randomClip = clips[randomClipIndex];
			audioSource.PlayOneShot(randomClip);
		}
		public void PlayRandomBasketSound()
		{
			PlayRandomSound(basketTouched);
		}
		public void PlayRandomEndSound()
		{
			PlayRandomSound(endJingle);
		}
	}

}
