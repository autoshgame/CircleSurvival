using UnityEngine;

namespace AutoShGame.Base.Observer
{ 
    public class MockListener : MonoBehaviour, IObserver<MockChannel>
    {
        private void Awake()
        {
            Observer.Instance?.RegisterObserver(this);
        }

        private void OnDisable()
        {
            Observer.Instance?.RemoveObserver(this);
        }

        public void OnObserverNotify(MockChannel data)
        {
            Debug.Log($"LISTENER UPDATE WITH CHANNEL : {data.message}");
        }
    }
}
