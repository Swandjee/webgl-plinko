using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class SoundManager : MonoBehaviour
    {
        public AudioClip[] ballHit;
        public AudioClip[] basketTouched;
        public AudioClip endJingle;
        private SoundManager _instance
        {
            get
            {
                return this;
            }
        }
        public static SoundManager Instance
        {
            get
            {
                var manager = FindObjectOfType<SoundManager>();
                return manager._instance;
            }
        }
    }

}
