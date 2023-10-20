using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[CreateAssetMenu(fileName = "Sound", menuName = "Common/Sounds", order = 1)]
public class SoundSO : ScriptableObject
{
    public SerializableDictionaryBase<string, AudioClip> props;
}

public class SoundUtils
{
    public static string BGM = "Main_Music";
    public static string SWORD_SLASH = "sword_slash";
    public static string SWORD_HIT = "sword_hit";
    public static string HUMAN_DEATH = "human_death";
    public static string HUMAN_LEVEL_UP = "human_upgrade";
    public static string BUTTON_CLICK = "button_click";
}