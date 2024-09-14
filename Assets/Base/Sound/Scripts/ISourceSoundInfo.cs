using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoShGame.Base.Sound
{
    public interface ISourceSoundInfo
    {
        public void ApplyGlobalConfig(float volume);

        /// <summary>
        /// When you need to change the volume in the audio source, must use the SetVolume Function
        /// <br></br>
        /// <br></br>
        /// Q: Why ?
        /// <br></br>
        /// A: Because there are a lots of impact on the volume that need a big config (Global sound with the settings sound)
        /// </summary>
        /// <param name="volume"></param>
        public void SetVolume(float volume);


        /// <summary>
        /// Set the parents for the audio source
        /// </summary>
        /// <param name="parents"></param>
        public void SetParents(Transform parents);

        /// <summary>
        /// Play the source
        /// </summary>
        public void Play();

        /// <summary>
        /// Get the source ID
        /// <br></br>
        /// Source ID is used to restore the audioSource to recycled audioSource
        /// </summary>
        /// <returns></returns>
        public int GetSourceID();

        /// <summary>
        /// Change the AudioClip of the source
        /// </summary>
        /// <param name="audioClip"></param>
        public void SetAudioClip(AudioClip audioClip);
    }
}

public enum ISourceSoundInfoState
{
    PLAYED,
    PAUSED,
}
