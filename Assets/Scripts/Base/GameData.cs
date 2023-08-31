using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
        } else
        {
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
}

[System.Serializable]
public class UserData
{
    public float sliderValue;
}
