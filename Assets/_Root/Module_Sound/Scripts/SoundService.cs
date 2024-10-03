using AutoShGame.Base.Observer;
using UnityEngine;
using System;
using AutoShGame.Base.Sound;

public class SoundService : MonoBehaviour, ISoundService
{
    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = GetComponent<SoundManager>();

        float volume = PlayerPrefs.GetFloat(Constant.KEY_CONFIG_VOLUME, 1f);
        soundManager.SetISoundSourceInfoImpl(typeof(AudioSourceImpl));
        soundManager.ChangeVolume(volume);
    }

    public void Play(AudioClip audio, Vector3 position, SourceConfigType sourceConfigType = SourceConfigType.TwoD, bool loop = false)
    {
        soundManager.Play(audio, position, sourceConfigType: sourceConfigType, loop: loop);
    }

    public ISourceSoundInfo PlayKeepSource(AudioClip audio, SourceConfigType sourceConfigType = SourceConfigType.TwoD, bool loop = false, Transform parent = null)
    {
        return soundManager.PlayKeepSource(audio, sourceConfigType, loop, parent);
    }

    public void ChangeVolume(float volume)
    {
        soundManager.ChangeVolume(volume);
    }

    public void Release(int audioSourceInstanceID)
    {
        soundManager.ReleaseAudioSource(audioSourceInstanceID);
    }
}

public interface ISoundService
{
    public void Play(AudioClip audio, Vector3 position, SourceConfigType sourceConfigType = SourceConfigType.TwoD, bool loop = false);
    public ISourceSoundInfo PlayKeepSource(AudioClip audio, SourceConfigType sourceConfigType = SourceConfigType.TwoD, bool loop = false, Transform parent = null);
    public void ChangeVolume(float volume);
    public void Release(int audioSourceInstanceID);
}


