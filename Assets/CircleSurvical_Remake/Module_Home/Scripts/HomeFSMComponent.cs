using UnityEngine;
using UnityEngine.UI;

namespace CircleSurvival.Module.HomeMenu
{
    public class HomeFSMComponent : MonoBehaviour
    {
        [Header("INIT STATE")]
        public HomeFSMManager manager;
        public Button buttonSettings;
        public Button buttonPlayGame;
        public Button buttonShop;
        public Button buttonExitGame;
    }
}
