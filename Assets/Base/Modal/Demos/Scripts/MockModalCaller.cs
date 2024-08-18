using UnityEngine;

namespace AutoShGame.Base.Modal
{
    public class MockModalCaller : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ModalManager.Instance.Push<MockModal2>();
        }
    }
}
