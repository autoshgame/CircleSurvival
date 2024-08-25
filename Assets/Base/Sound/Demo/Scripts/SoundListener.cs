using AutoShGame.Base.Observer;
using UnityEngine;
using System;

namespace AutoShGame.Base.Sound
{
    public class SoundListener : MonoBehaviour, IObservableAutoSh<SoundTopic>
    {
        private void OnEnable()
        {
            Observer.Observer.Instance?.RegisterObserver(this);
        }

        private void OnDisable()
        {
            Observer.Observer.Instance?.RemoveObserver(this);
        }

        public void OnObserverNotify(SoundTopic data)
        {
            if (!data.isKeepSource)
            {
                SoundManager.Instance.Play(data.audioClip);
            }
            else
            {
                ISourceSoundInfo sourceSoundInfo = SoundManager.Instance.Play(data.audioClip, sourceConfigType: data.sourceConfigType, data.loop);
                data.OnReceiveSourceSound?.Invoke(sourceSoundInfo);
            }
        }
    }

    public class SoundTopic
    {
        public SourceConfigType sourceConfigType { get; }
        public Action<ISourceSoundInfo> OnReceiveSourceSound { get; }
        public AudioClip audioClip {get; }
        public bool isKeepSource { get; }
        public bool loop { get; }

        public SoundTopic(AudioClip audioClip, SourceConfigType sourceConfigType, Action<ISourceSoundInfo> OnReceiveSourceSound = null, bool loop = false)
        {
            this.sourceConfigType = sourceConfigType;
            this.OnReceiveSourceSound = OnReceiveSourceSound;
            this.audioClip = audioClip;
            this.loop = loop;
            isKeepSource = true;
        }

        public SoundTopic(AudioClip audioClip)
        {
            this.audioClip = audioClip;
            isKeepSource = false;
            loop = false;
        }
    }
}
