using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoShGame.Base.Sound
{
    public class AudioSourceImpl : MonoBehaviour, ISourceSoundInfo
    {
        private AudioSource audioSource;
        private int curVolume = 1;
        private bool isInit;

        private void Awake()
        {
            this.audioSource = GetComponent<AudioSource>();    
        }

        public void SetParents(Transform parents)
        {
            gameObject.transform.parent = parents;
        }

        public void SetVolume(float volume)
        {
            audioSource.volume = volume * curVolume;
        }

        public void ApplyGlobalConfig(int volume)
        {
            if (!isInit)
            {
                curVolume = volume;
                isInit = true;
            }
        }

        public void Play()
        {
            audioSource.Play();
        }

        public int GetSourceID()
        {
            return audioSource.GetInstanceID();
        }

        public void SetAudioClip(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
        }
    }
}
