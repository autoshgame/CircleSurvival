using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using AutoShGame.Base.Observer;

public class PlayerDataManager : MonoBehaviour, IDataService
{
    private string filepath;
    private PlayerData userData;

    private void Awake()
    {
        filepath = $"{Application.persistentDataPath}/user.json";
        LoadUserData();
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

    public PlayerData GetUserData()
    {
        return userData;
    }

    public void SaveUserData(PlayerData playerData)
    {
        userData = playerData;
        SaveUserData();
    }
}

public interface IDataService
{
    public PlayerData GetUserData();
    public void SaveUserData(PlayerData playerData);
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


