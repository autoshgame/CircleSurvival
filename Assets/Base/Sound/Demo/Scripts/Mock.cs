using UnityEngine;

namespace AutoShGame.Base.Sound 
{
    public class Mock : MonoBehaviour
    {
        [SerializeField] private AudioClip audioMock;

        // Start is called before the first frame update
        void Start()
        {
            AudioSource audio = SoundManager.Instance.PlayFx(audioMock, transform, OnDone);
            SoundManager.Instance.Stop(audio.GetInstanceID());
        }

        void OnDone()
        {
            Debug.Log("DONE AUDIO");
        }
    }
}
