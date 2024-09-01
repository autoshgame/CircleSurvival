using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using AutoShGame.Base.MonoSingleton;

namespace AutoShGame.Base.Sound 
{
    /// <summary>
    /// Base class for sound manager
    /// <br></br>
    /// <br></br>
    /// Mising : <br></br>
    /// 1 : Volume <br></br>
    /// 2 : Channel : In_Game, VFX,SFX <br></br>
    /// 3 : Modification for audio source <br></br>
    /// 4 : Pause, Start An audio source and OnDone Callback <br></br>
    /// 5 : AudioSource config (Can we seperate create audiosource + play ?)
    /// </summary>
    public class SoundManager : Singleton<SoundManager>
    {

        private List<AudioSource> currentPlayAudioSource = new List<AudioSource>();
        private List<AudioSource> donePlayAudioSource = new List<AudioSource>();

        private SourceSoundInfoTypeResolver typeResolver = new SourceSoundInfoTypeResolver();
        private SourceConfigResolver configResolver = new SourceConfigResolver();

        public ISourceSoundInfo PlayKeepSource(AudioClip audio, SourceConfigType sourceConfigType = SourceConfigType.TwoD, bool loop = false, Transform parent = null) 
        {
            ISourceSoundInfo iSourceSoundInfo = null;
            AudioSource audioSource = null;

            Type T = typeResolver.ResolveType();

            if (donePlayAudioSource.Count > 0) 
            {
                audioSource = donePlayAudioSource[donePlayAudioSource.Count - 1];
                donePlayAudioSource.RemoveAt(donePlayAudioSource.Count - 1);
                AddPlayAudioSource(audioSource, audio, loop, audio.name, sourceConfigType);
                iSourceSoundInfo = audioSource.GetComponent(T) as ISourceSoundInfo;
            }
            else
            {
                GameObject source = new GameObject();
                audioSource = source.AddComponent<AudioSource>();
                AddPlayAudioSource(audioSource, audio, loop, audio.name, sourceConfigType);
                iSourceSoundInfo = source.AddComponent<AudioSourceImpl>() as ISourceSoundInfo;
            }

            if (parent != null) audioSource.transform.parent = parent;
            StartCoroutine(IEPlay(audio.length, audioSource, true));
            return iSourceSoundInfo;
        }

        public void Play(AudioClip audio, SourceConfigType sourceConfigType = SourceConfigType.TwoD, bool loop = false, Transform parent = null)
        {
            ISourceSoundInfo iSourceSoundInfo = null;
            AudioSource audioSource = null;

            Type T = typeResolver.ResolveType();

            if (donePlayAudioSource.Count > 0)
            {
                audioSource = donePlayAudioSource[donePlayAudioSource.Count - 1];
                donePlayAudioSource.RemoveAt(donePlayAudioSource.Count - 1);
                AddPlayAudioSource(audioSource, audio, loop, audio.name, sourceConfigType);
                iSourceSoundInfo = audioSource.GetComponent(T) as ISourceSoundInfo;
            }
            else
            {
                GameObject source = new GameObject();
                audioSource = source.AddComponent<AudioSource>();
                AddPlayAudioSource(audioSource, audio, loop, audio.name, sourceConfigType);
                iSourceSoundInfo = source.AddComponent<AudioSourceImpl>() as ISourceSoundInfo;
            }

            if (parent != null) audioSource.transform.parent = parent;
            StartCoroutine(IEPlay(audio.length, audioSource, false));
        }

        private IEnumerator IEPlay(float audioTime, AudioSource audioSource, bool isKeepSource)
        {
            if (!isKeepSource)
            {
                yield return new WaitForSeconds(audioTime);
                currentPlayAudioSource.Remove(audioSource);
                donePlayAudioSource.Add(audioSource);
            }
            else
            {
                yield return null;
            }
        }

        private void AddPlayAudioSource(AudioSource audioSource, AudioClip clip, bool loop, string name, SourceConfigType sourceConfigType = SourceConfigType.TwoD)
        {
            //Apply config for audiosource
            audioSource.clip = clip;
            audioSource.loop = loop;
            audioSource.gameObject.name = name;
            
            SourceConfigProps configProps = configResolver.GetSourceConfigs(sourceConfigType);

            audioSource.rolloffMode = configProps.rolloffMode;
            audioSource.dopplerLevel = configProps.dopplerLevel;
            audioSource.spread = configProps.spread;
            audioSource.maxDistance = configProps.minDistance;
            audioSource.maxDistance = configProps.maxDistance;
            audioSource.spatialBlend = configProps.spatialBlend;

            currentPlayAudioSource.Add(audioSource);
        }
    }
}
