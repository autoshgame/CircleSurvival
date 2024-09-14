using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
[CustomEditor(typeof(PlayerDataManager))]
public class PlayerDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PlayerDataManager a = (PlayerDataManager)target;
        if (GUILayout.Button("ResetData"))
        {
            a.ResetUserData();
        }
    }
}
