using UnityEngine;
using AutoShGame.Base.Sound;
using AutoShGame.Base.ServiceProvider;

public class HomeBGSoundController : MonoBehaviour
{
    [SerializeField] private AudioClip bgAudioClip;
    private ISourceSoundInfo sourceSoundInfo;

    public void PlaySound()
    {
        sourceSoundInfo = ServiceProvider.Resolve<ISoundService>().PlayKeepSource(bgAudioClip, loop: true, parent: this.transform);
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

    private void OnDestroy()
    {
        ServiceProvider.Resolve<ISoundService>().Release(sourceSoundInfo.GetSourceID());
        sourceSoundInfo = null;
    }
}
