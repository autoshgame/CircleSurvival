using System.Collections;
using UnityEngine;
using AutoShGame.Base.Sound;
using AutoShGame.Base.Observer;

public class HomeBGSoundController : MonoBehaviour
{
    [SerializeField] private AudioClip bgAudioClip;
    private ISourceSoundInfo sourceSoundInfo;

    public void PlaySound()
    {
        SoundTopic bgSoundTopic = new SoundTopic(bgAudioClip, SourceConfigType.TwoD, OnReceiveSourceSound: (value) => sourceSoundInfo = value, loop: true);
        Observer.Instance.NotifyObservers(bgSoundTopic);
        StartCoroutine(IPlaySound());
    }

    IEnumerator IPlaySound()
    {
        yield return new WaitUntil(() => sourceSoundInfo != null);
        sourceSoundInfo.Play();
    }

    private void OnApplicationPause(bool pause)
    {
        if (sourceSoundInfo != null)
        {
            sourceSoundInfo.SetAudioClip(bgAudioClip);
            sourceSoundInfo.Play();
        }
    }
}
