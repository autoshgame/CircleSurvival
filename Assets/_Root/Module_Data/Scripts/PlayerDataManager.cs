using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using AutoShGame.Base.Observer;

public class PlayerDataManager : MonoBehaviour, IObservableAutoSh<CurrencyDataTopic>, IObservableAutoSh<SkinDataTopic>
{
    private string filepath;
    private PlayerData userData;

    CurrencyData currencyGroup = new CurrencyData();
    SkinData skinData = new SkinData();

    private void Awake()
    {
        filepath = $"{Application.persistentDataPath}/user.json";
        LoadUserData();
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
        LoadUserData();

        if (data.actionType == ActionType.GET)
        {
            currencyGroup.coin = userData.currency.coin;
            data.result?.Invoke(currencyGroup);
            data.onLoadSuccess?.Invoke(true);
        }
        else if (data.actionType == ActionType.UPDATE)
        {
            userData.currency.coin = data.updateData.coin;
            SaveUserData();
            data.onLoadSuccess?.Invoke(true);
        }
    }

    public void OnObserverNotify(SkinDataTopic data)
    {
        LoadUserData();

        if (data.actionType == ActionType.GET)
        {
            skinData.choosenSword = userData.weapon.currentSword;
            skinData.ownedSwords = userData.weapon.availableSword;
            data.result?.Invoke(skinData);
            data.onLoadSuccess?.Invoke(true);
        }
        else if (data.actionType == ActionType.UPDATE)
        {
            userData.weapon.currentSword = data.updateData.choosenSword;
            userData.weapon.availableSword = data.updateData.ownedSwords;
            SaveUserData();
            data.onLoadSuccess?.Invoke(true);
        }
    }

    private void LoadUserData()
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

    private void SaveUserData()
    {
        File.WriteAllText(filepath, JsonUtility.ToJson(userData));
    }

    public void ResetUserData()
    {
        if (File.Exists(filepath))
        {
            File.Delete(filepath);
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
            coin = 1000
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

[System.Serializable]
public class CurrencyDataTopic
{
    public Action<CurrencyData> result;
    public CurrencyData updateData;
    public Action<bool> onLoadSuccess;
    public ActionType actionType;
}

[System.Serializable]
public class SkinDataTopic
{
    public Action<SkinData> result;
    public SkinData updateData;
    public Action<bool> onLoadSuccess;
    public ActionType actionType;
}

[System.Serializable]
public class SkinData
{
    public List<SwordEnum> ownedSwords;
    public SwordEnum choosenSword;
}

[System.Serializable]
public class CurrencyData
{
    public int coin;
}

public enum ActionType
{
    GET,
    INSERT,
    UPDATE,
    DELETE
}


