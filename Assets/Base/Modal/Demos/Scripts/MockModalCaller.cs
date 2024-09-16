using UnityEngine;

namespace AutoShGame.Base.Modal
{
    public class MockModalCaller : MonoBehaviour
    {
        [SerializeField] private AudioClip audioTest;

        // Start is called before the first frame update
        void Start()
        {
            //ModalManager.Instance.Push<SettingsModal>().Show();

            //SoundTopic sound = new SoundTopic(audioTest);
            //AutoShGame.Base.ObserverAutoSh.ObserverAutoSh.NotifyObservers(sound);
        }
    }
}
