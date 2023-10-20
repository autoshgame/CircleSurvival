using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class GameData : Singleton<GameData>
{
    [SerializeField] private UserData userData;
    string filepath = "";

    private void Start()
    {
        filepath = Application.persistentDataPath + "/data.json";
        LoadUserData();
    }

    public void LoadUserData()
    {
        if (File.Exists(filepath)) {
            string fileContent = File.ReadAllText(filepath);
            userData = JsonUtility.FromJson<UserData>(fileContent);
        } else {
            UserData data = new UserData();
            File.WriteAllText(filepath, JsonUtility.ToJson(data));
        }
    }

    public void SaveUserData(UserData userData)
    {
        File.WriteAllText(filepath, JsonUtility.ToJson(userData));
    }

    public UserData GetUserData()
    {
        return userData;
    }

    public void ResetUserData(string path)
    {
        UserData data = new UserData();
        File.WriteAllText(path, JsonUtility.ToJson(data));
    }

    public void SetCoin(int value)
    {
        userData.coin = value;
        SaveUserData(userData);
    }

    public void SelectSwordSkin(SwordEnum value)
    {
        userData.currentSword = value;
        SaveUserData(userData);
    }

    public void AddSwordSkin(SwordEnum value)
    {
        if (!userData.availableSword.Contains(value))
        {
            userData.availableSword.Add(value);
            SaveUserData(userData);
        }
    }
}

[System.Serializable]
public class UserData
{
    public float sliderValue = 0;
    public int coin = 0;
    public List<SwordEnum> availableSword = new List<SwordEnum>
    {
        SwordEnum.SWORD_1
    };
    public SwordEnum currentSword = SwordEnum.SWORD_1;

    public UserData()
    {
        sliderValue = 0;
        coin = 0;
        currentSword = SwordEnum.SWORD_1;
        availableSword = new List<SwordEnum>
        {
            currentSword
        };
    }
}
