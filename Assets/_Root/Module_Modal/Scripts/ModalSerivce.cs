using UnityEngine;
using System;
using AutoShGame.Base.Modal;
using AutoShGame.Base.Observer;

public class ModalSerivce : MonoBehaviour, IModalService
{
    private ModalManager modalManager;

    private void Awake()
    {
        modalManager = GetComponent<ModalManager>();
    }

    public BaseModal Push<T>(bool cache = false)
    {
        return modalManager.Push(typeof(T), shouldCache: cache);
    }
}

public interface IModalService
{
    public BaseModal Push<T>(bool cache = false);
}

