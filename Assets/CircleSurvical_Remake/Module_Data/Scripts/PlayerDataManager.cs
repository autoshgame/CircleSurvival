using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using AutoShGame.Base.Observer;

public class PlayerDataManager : MonoBehaviour, AutoShGame.Base.Observer.IObservableAutoSh<CurrencyDataTopic>
{
    private string filepath;
    private PlayerData userData;

    private void Awake()
    {
        filepath = Application.persistentDataPath + "/playerData.json";
        LoadUserData();
    }

    private void OnEnable()
    {
        Observer.Instance?.RegisterObserver<CurrencyDataTopic>(this);
    }

    private void OnDisable()
    {
        Observer.Instance?.RemoveObserver<CurrencyDataTopic>(this);
    }

    public void LoadUserData()
    {
        if (File.Exists(filepath))
        {
            string fileContent = File.ReadAllText(filepath);
            userData = JsonUtility.FromJson<PlayerData>(fileContent);
        }
        else
        {
            userData = new PlayerData();
            File.WriteAllText(filepath, JsonUtility.ToJson(userData));
        }
    }

    public void OnObserverNotify(CurrencyDataTopic data)
    {
        CurrencyData currencyGroup = new CurrencyData();
        currencyGroup.coin = userData.currency.coin;
        
        Debug.Log($"SET DATA : {currencyGroup.coin}");

        if (data.actionType == ActionType.GET)
        {
            data.result?.Invoke(currencyGroup);
            data.onLoadSuccess?.Invoke(true);
        }
    }
}

[Serializable]
public class PlayerData
{
    public Currency currency;
    public Weapon weapon;

    public PlayerData()
    {
        currency = new Currency
        {
            coin = 5
        };

        weapon = new Weapon
        {
            availableSword = new List<SwordEnum>() { SwordEnum.SWORD_1 },
            currentSword = SwordEnum.SWORD_1
        };
    }
}

[Serializable]
public class Currency
{
    public int coin;
}

[Serializable]
public class Weapon
{
    public List<SwordEnum> availableSword;
    public SwordEnum currentSword;
}


