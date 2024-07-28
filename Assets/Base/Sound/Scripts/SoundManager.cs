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
        private readonly Dictionary<int, AudioSource> fxAudioSource = new Dictionary<int, AudioSource>();
        private readonly Dictionary<int, AudioSource> backGroundAudioSource = new Dictionary<int, AudioSource>();


        public AudioSource PlayFx(AudioClip audio, Transform parent = null, Action onDone = null) 
        {
            GameObject go = new GameObject();
            go.name = audio.name;
            AudioSource audioSource = go.AddComponent<AudioSource>();
            fxAudioSource.Add(audioSource.GetInstanceID(), audioSource);
            StartCoroutine(IPlayFx(audioSource, audio, parent, onDone));
            return audioSource;
        }

        private IEnumerator IPlayFx(AudioSource audioSource, AudioClip audio, Transform parent = null, Action onDone = null) 
        {
            audioSource.PlayOneShot(audio);

            if (parent != null) 
            {
                audioSource.transform.parent = parent;
            }

            yield return new WaitForSeconds(audio.length);

            fxAudioSource.Remove(audioSource.GetInstanceID());

            if (audioSource != null) 
            {              
                Destroy(audioSource.gameObject);        
                onDone?.Invoke();            
            }
        }

        public void StopAllFX() 
        {
            foreach (KeyValuePair<int, AudioSource> item in fxAudioSource) 
            {
                item.Value.Stop();
                Destroy(item.Value.gameObject);       
            }

            fxAudioSource.Clear();
        }

        public void PlayBySource(AudioClip audio, Transform parent = null) 
        {
            GameObject go = new GameObject();
            go.name = audio.name;
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.clip = audio;
            backGroundAudioSource.Add(audioSource.GetInstanceID(), audioSource);
            StartCoroutine(IPlayBySource(audioSource, audio, parent));      
        }
    
        public IEnumerator IPlayBySource(AudioSource audioSource, AudioClip audio, Transform parent = null) 
        {
            if (parent != null)
            {
                audioSource.transform.parent = parent;
            }

            audioSource.Play();
            yield return null;
        }

        public void StopALLSourceSound() 
        {
            foreach (KeyValuePair<int, AudioSource> item in backGroundAudioSource) 
            {
                item.Value.Stop();
                Destroy(item.Value.gameObject);       
            }

            backGroundAudioSource.Clear();
        }

        public void Stop(int audioSourceID) 
        {
            if (fxAudioSource.ContainsKey(audioSourceID)) 
            {
                fxAudioSource[audioSourceID].Stop();
                fxAudioSource.Remove(audioSourceID);
                DestroyImmediate(fxAudioSource[audioSourceID].gameObject);
            }

            if (backGroundAudioSource.ContainsKey(audioSourceID)) 
            {
                backGroundAudioSource[audioSourceID].Stop();
                backGroundAudioSource.Remove(audioSourceID);
                DestroyImmediate(backGroundAudioSource[audioSourceID].gameObject);
            }
        }
    }
}
