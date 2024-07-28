using UnityEngine;
using System.Collections.Generic;

namespace AutoShGame.Base.Popup
{
    public class DirectReferencePopupSource : MonoBehaviour, IPopupSource
    {
        [SerializeField] private List<DemoPopupSource> popupSource;

        public BasePopup GetPopupBySource(string namePopup)
        {
            BasePopup popupGet = null;

            foreach (var item in popupSource)
            {
                if (item.popupName == namePopup)
                {
                    popupGet = item.popupPrefab;
                    break;
                }
            }

            if (popupGet == null) Debug.LogError($"Popup {namePopup} dont exists");
            return popupGet;
        }
    }

    [System.Serializable]
    public class DemoPopupSource
    {
        public string popupName;
        public BasePopup popupPrefab;
    }
}
