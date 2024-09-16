using UnityEngine;

namespace AutoShGame.Base.Observer
{ 
    public class MockListener : MonoBehaviour, IObservableAutoSh<MockChannel>
    {
        private void Awake()
        {
            ObserverAutoSh.RegisterObserver(this);
        }

        private void OnDisable()
        {
            ObserverAutoSh.RemoveObserver(this);
        }

        public void OnObserverNotify(MockChannel data)
        {
            Debug.Log($"LISTENER UPDATE WITH CHANNEL : {data.message}");
        }
    }
}
