using UnityEngine;
using AutoShGame.Base.Sound;
using AutoShGame.Base.Observer;

namespace AutoShGame.Base.Modal
{
    public class MockModalCaller : MonoBehaviour
    {
        [SerializeField] private AudioClip audioTest;

        // Start is called before the first frame update
        void Start()
        {
            ModalManager.Instance.Push<SettingsModal>().Show();

            SoundTopic sound = new SoundTopic(audioTest);
            AutoShGame.Base.Observer.Observer.Instance.NotifyObservers(sound);
        }
    }
}
