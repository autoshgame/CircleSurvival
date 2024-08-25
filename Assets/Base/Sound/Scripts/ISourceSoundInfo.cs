using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoShGame.Base.Sound
{
    public interface ISourceSoundInfo
    {
        public void ApplyGlobalConfig(int volume);

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
    }
}

public enum ISourceSoundInfoState
{
    PLAYED,
    PAUSED,
}
