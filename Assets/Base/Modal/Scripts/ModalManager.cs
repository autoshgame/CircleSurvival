using System.Collections.Generic;
using UnityEngine;
using System;
using AutoShGame.Base.MonoSingleton;
using System;

namespace AutoShGame.Base.Modal 
{
    public class ModalManager : Singleton<ModalManager>
    {
        private IModalSource _modalSource;
        private readonly Dictionary<Type, BaseModal> modals = new Dictionary<Type, BaseModal>();

        protected override void Awake()
        {
            base.Awake();

            _modalSource = GetComponent<IModalSource>();

            if (_modalSource == null)
            {
                Debug.LogError("MODAL SOURCE CANNOT BE NULL");
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Push a modal. The modal need a canvas
        /// </summary>
        /// <param name="popupName"></param>
        /// <param name="shouldCache"></param>
        /// <returns></returns>
        public BaseModal Push<T>(bool shouldCache = false)
        {
            Type type = typeof(T);
            if (modals.ContainsKey(type))
            {
                if (modals[type] != null)
                {
                    modals[type].Show();
                    return modals[type];
                }
                else 
                {
                    modals.Remove(type);
                }
            }

            BaseModal ele = Instantiate(_modalSource.GetModalBySource<T>());

            if (shouldCache == true) 
            {
                modals.Add(type, ele);
            }
            
            return ele;
        }

        /// <summary>
        /// Get a popup by its name (If it is cached)
        /// </summary>
        /// <param name="popupName"></param>
        /// <returns></returns>
        public BaseModal Get<T>()
        {
            Type type = typeof(T);
            if (modals.ContainsKey(type) && modals[type] != null)
            {
                return modals[type];
            }
            
            Debug.LogError("WARNING , MODAl " + type.Name + " DONT EXSISTS");
            return null;
        }
    }
}
