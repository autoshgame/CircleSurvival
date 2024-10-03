using UnityEngine;
using System.Collections;

namespace AutoShGame.Base.Sound
{
    public class Mock : MonoBehaviour
    {
        [SerializeField] private AudioClip audioMock;

        // Start is called before the first frame update
        IEnumerator Start()
        {

            //ISourceSoundInfo iSourceSOundInfo = SoundManager.Instance.Play(audioMock, sourceConfigType: SourceConfigType.TwoD, parent: this.transform);
            //iSourceSOundInfo.Play();

            yield return null;

            //soundTopic = new SoundTopic(audioMock, SourceConfigType.ThreeD, (value) => soundInfo = value, false);
            //ObserverAutoSh.ObserverAutoSh.NotifyObservers(soundTopic);
            //yield return new WaitUntil(() => soundInfo != null);
            //soundInfo.Play();

            //yield return new WaitForSeconds(1f);

            //soundTopic = new SoundTopic(audioMock);
            //ObserverAutoSh.ObserverAutoSh.NotifyObservers(soundTopic);
            //soundInfo.Play();


            /*
            yield return null;

            yield return null;
            //yield return new WaitForSeconds(2f);\

            SoundManager.Instance.Play(audioMock);

            //yield return new WaitForSeconds(2f);
            SoundManager.Instance.Play(audioMock);
            //yield return new WaitForSeconds(2f);
            SoundManager.Instance.Play(audioMock);
            yield return new WaitForSeconds(3f);

            SoundManager.Instance.Play(audioMock);
            yield return null;
            //yield return new WaitForSeconds(2f);
            SoundManager.Instance.Play(audioMock);
            //yield return new WaitForSeconds(2f);
            SoundManager.Instance.Play(audioMock);
            //yield return new WaitForSeconds(2f);
            SoundManager.Instance.Play(audioMock);
            //yield return new WaitForSeconds(2f);
            */
        }
    }
}
