using AutoShGame.Base.Observer;
using UnityEngine;
using System;

namespace AutoShGame.Base.Sound
{
    public class SoundListener : MonoBehaviour, IObservableAutoSh<SoundTopic>, IObservableAutoSh<SoundReleaseTopic>
    {
        private void OnEnable()
        {
            Observer.Observer.Instance?.RegisterObserver<SoundTopic>(this);
            Observer.Observer.Instance?.RegisterObserver<SoundReleaseTopic>(this);
        }

        private void OnDisable()
        {
            Observer.Observer.Instance?.RemoveObserver<SoundTopic>(this);
            Observer.Observer.Instance?.RemoveObserver<SoundReleaseTopic>(this);
        }

        public void OnObserverNotify(SoundTopic data)
        {
            if (!data.isKeepSource)
            {
                SoundManager.Instance.Play(data.audioClip, data.position, sourceConfigType: data.sourceConfigType);
            }
            else
            {
                ISourceSoundInfo sourceSoundInfo = SoundManager.Instance.PlayKeepSource(data.audioClip, sourceConfigType: data.sourceConfigType, data.loop);
                data.OnReceiveSourceSound?.Invoke(sourceSoundInfo);
            }
        }

        public void OnObserverNotify(SoundReleaseTopic data)
        {
            SoundManager.Instance.ReleaseAudioSource(data.sourceSoundInfoInstanceID);
        }
    }

    public class SoundTopic
    {
        public SourceConfigType sourceConfigType { get; }
        public Action<ISourceSoundInfo> OnReceiveSourceSound { get; }
        public AudioClip audioClip {get; }
        public bool isKeepSource { get; }
        public bool loop { get; }
        public Vector3 position { get; }

        /// <summary>
        /// Initialization for keep source Sound
        /// </summary>
        /// <param name="audioClip"></param>
        /// <param name="sourceConfigType"></param>
        /// <param name="OnReceiveSourceSound"></param>
        /// <param name="loop"></param>
        public SoundTopic(AudioClip audioClip, SourceConfigType sourceConfigType, Action<ISourceSoundInfo> OnReceiveSourceSound = null, bool loop = false)
        {
            this.sourceConfigType = sourceConfigType;
            this.OnReceiveSourceSound = OnReceiveSourceSound;
            this.audioClip = audioClip;
            this.isKeepSource = true;
            this.loop = loop;
            isKeepSource = true;
        }

        /// <summary>
        /// Initialization for not keep source sound
        /// </summary>
        /// <param name="audioClip"></param>
        /// <param name="sourceConfigType"></param>
        public SoundTopic(AudioClip audioClip, Vector3 position, SourceConfigType sourceConfigType = SourceConfigType.TwoD)
        {
            this.audioClip = audioClip;
            this.sourceConfigType = sourceConfigType;
            this.position = position;
            loop = false;
        }

        public SoundTopic(AudioClip audioClip, SourceConfigType sourceConfigType = SourceConfigType.TwoD)
        {
            this.audioClip = audioClip;
            this.sourceConfigType = sourceConfigType;
            this.position = Vector3.zero;
            loop = false;
        }
    }

    public class SoundReleaseTopic
    {
        public int sourceSoundInfoInstanceID;

        public SoundReleaseTopic(int sourceSoundInfoInstanceID)
        {
            this.sourceSoundInfoInstanceID = sourceSoundInfoInstanceID;
        }
    }
}
