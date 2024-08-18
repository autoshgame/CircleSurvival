using System;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace AutoShGame.Base.Modal
{
    public class DirectReferenceModalSource : MonoBehaviour, IModalSource
    {
        [SerializeField] private List<BaseModal> listModals;

        private Dictionary<Type, BaseModal> modals = new Dictionary<Type, BaseModal>();

        private void Awake()
        {
            for (int i = 0; i < listModals.Count; ++i)
            {
                modals.Add(listModals[i].GetType(), listModals[i]);;
            }
        }

        public BaseModal GetModalBySource<T>()
        {
            return modals[typeof(T)];
        }
    }
}
