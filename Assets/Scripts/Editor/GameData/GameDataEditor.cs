using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameData))]
public class GameDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GameData a = (GameData)target;

        string filepath = Application.persistentDataPath + "/data.json";

        if (GUILayout.Button("ResetData")) {
            a.ResetUserData(filepath);
        }    

    }
}
