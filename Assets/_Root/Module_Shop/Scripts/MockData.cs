using AutoShGame.Base.Observer;
using UnityEngine;
using System.Collections.Generic;

public class MockData : MonoBehaviour, IObservableAutoSh<CurrencyDataTopic>, IObservableAutoSh<SkinDataTopic>
{
    CurrencyData currencyGroup = new CurrencyData();
    SkinData skinData = new SkinData();

    private void Awake()
    {
        currencyGroup.coin = 1000;
        skinData.ownedSwords = new List<SwordEnum>() { SwordEnum.SWORD_1 };
        skinData.choosenSword = SwordEnum.SWORD_1;
    }

    private void OnEnable()
    {
        ObserverAutoSh.RegisterObserver<CurrencyDataTopic>(this);
        ObserverAutoSh.RegisterObserver<SkinDataTopic>(this);
    }

    private void OnDisable()
    {
        ObserverAutoSh.RemoveObserver<CurrencyDataTopic>(this);
        ObserverAutoSh.RemoveObserver<SkinDataTopic>(this);

    }

    public void OnObserverNotify(CurrencyDataTopic data)
    {
        if (data.actionType == ActionType.GET)
        {
            data.result?.Invoke(currencyGroup);
            data.onLoadSuccess?.Invoke(true);
        }
        else if (data.actionType == ActionType.UPDATE)
        {
            currencyGroup.coin = data.updateData.coin;
            data.onLoadSuccess?.Invoke(true);
        }
    }

    public void OnObserverNotify(SkinDataTopic data)
    {
        if (data.actionType == ActionType.GET)
        {
            data.result?.Invoke(skinData);
            data.onLoadSuccess?.Invoke(true);
        }
        else if (data.actionType == ActionType.UPDATE)
        {
            skinData.choosenSword = data.updateData.choosenSword;
            skinData.ownedSwords = data.updateData.ownedSwords;
            data.onLoadSuccess?.Invoke(true);
        }
    }
}
