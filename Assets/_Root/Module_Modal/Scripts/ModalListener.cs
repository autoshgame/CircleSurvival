using UnityEngine;
using System;
using AutoShGame.Base.Modal;
using AutoShGame.Base.Observer;

public class ModalListener : MonoBehaviour, IObservableAutoSh<ModalTopic>
{
    private ModalManager modalManager;

    private void Awake()
    {
        modalManager = GetComponent<ModalManager>();
    }

    private void OnEnable()
    {
        ObserverAutoSh.RegisterObserver<ModalTopic>(this);
    }

    private void OnDisable()
    {
        ObserverAutoSh.RemoveObserver<ModalTopic>(this);
    }

    public void OnObserverNotify(ModalTopic data)
    {
        if (data.modalData != null)
        {
            modalManager.Push(data.modalType).InitData(data.modalData).Show();
        }
        else
        {
            modalManager.Push(data.modalType).Show();
        }
    }
}

public class ModalTopic
{
    public Type modalType;
    public object modalData;
}
