using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MenuEditor : MonoBehaviour
{
    [MenuItem("MyMenu/Enable MockService")]
    static void EnableMockService()
    {
        Debug.Log("Config Service Enable Mock Services !!!");

        string pathToconfigService = "Assets/_Root/Module_Configs/GlobalConfig.asset";

        ConfigScriptable configScriptable = AssetDatabase.LoadAssetAtPath<ConfigScriptable>(pathToconfigService);

        configScriptable.TurnOnMockService = true;

        AssetDatabase.SaveAssetIfDirty(configScriptable);
    }

    [MenuItem("MyMenu/Disable MockService")]
    static void DisableMockService()
    {
        Debug.Log("Config Service Disable Mock Services !!!");

        string pathToconfigService = "Assets/_Root/Module_Configs/GlobalConfig.asset";

        ConfigScriptable configScriptable = AssetDatabase.LoadAssetAtPath<ConfigScriptable>(pathToconfigService);

        configScriptable.TurnOnMockService = false;

        AssetDatabase.SaveAssetIfDirty(configScriptable);
    }

    [MenuItem("MyMenu/Open SPL Scene")]
    static void OpenSPLScene()
    {
        string pathTocSpl = "Assets/_Root/Module_SPL/Scene/Spl.unity";
        EditorSceneManager.OpenScene(pathTocSpl);
    }
}
