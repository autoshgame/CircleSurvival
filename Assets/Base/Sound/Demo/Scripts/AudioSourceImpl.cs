using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoShGame.Base.Sound
{
    public class AudioSourceImpl : MonoBehaviour, ISourceSoundInfo
    {
        private AudioSource audioSource;
        private float configVolume = 1;
        private float multiplyVolume = 1;

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
            multiplyVolume = volume;
            audioSource.volume = configVolume * multiplyVolume;
        }

        public void ApplyGlobalConfig(float volume)
        {
            configVolume = volume;
            audioSource.volume = configVolume * multiplyVolume;
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
