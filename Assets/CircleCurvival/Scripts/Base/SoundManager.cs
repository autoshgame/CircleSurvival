using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private SoundSO soundSO;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioMixer audioMixer;

    public SoundSO SoundSO { get => soundSO; set => soundSO = value; }

    private void Start()
    {
        HandleAudioVolumeChange(Mathf.Log10(GameData.Instance.GetUserData().sliderValue) * 20);
    }

    public void PlayAudio(string audioName)
    {
        audioSource.PlayOneShot(SoundSO.props[audioName]);
    }

    public void HandleAudioVolumeChange(float value)
    {
        audioMixer.SetFloat("MasterVolume", value);
    }
}
