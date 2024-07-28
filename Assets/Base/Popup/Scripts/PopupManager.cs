using System.Collections.Generic;
using UnityEngine;
using System;
using AutoShGame.Base.MonoSingleton;

namespace AutoShGame.Base.Popup 
{
    public class PopupManager : Singleton<PopupManager>
    {
        private IPopupSource _IPopupSource;
        private readonly Dictionary<string, BasePopup> popups = new Dictionary<string, BasePopup>();

        private void Awake()
        {
            _IPopupSource = GetComponent<IPopupSource>();

            if (_IPopupSource == null)
            {
                Debug.LogError("POPUP SOURCE CANNOT BE NULL");
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Push a popup. The popup require an own canvas
        /// </summary>
        /// <param name="popupName"></param>
        /// <param name="shouldCache"></param>
        /// <returns></returns>
        public BasePopup Push(string popupName, bool shouldCache = false)
        {
            if (popups.ContainsKey(popupName))
            {
                if (popups[popupName] != null)
                {
                    popups[popupName].Show();
                    return popups[popupName];
                }
                else 
                {
                    popups.Remove(popupName);
                }
            }

            BasePopup ele = Instantiate(_IPopupSource.GetPopupBySource(popupName));

            if (shouldCache == true) 
            {
                popups.Add(popupName, ele);
            }
            
            return ele;
        }

        /// <summary>
        /// Get a popup by its name (If it is cached)
        /// </summary>
        /// <param name="popupName"></param>
        /// <returns></returns>
        public BasePopup Get(string popupName)
        {
            if (popups.ContainsKey(popupName) && popups[popupName] != null)
            {
                return popups[popupName];
            }
            
            Debug.LogError("WARNING , POPUP " + popupName.ToString() + " DONT EXSISTS");
            return null;
        }
    }
}
