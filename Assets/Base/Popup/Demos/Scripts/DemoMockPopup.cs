using UnityEngine;

namespace AutoShGame.Base.Popup
{
    public class DemoMockPopup : MonoBehaviour
    {
        private void Start()
        {
            PopupManager.Instance.Push("Hello", false).Show();
        }
    }
}
