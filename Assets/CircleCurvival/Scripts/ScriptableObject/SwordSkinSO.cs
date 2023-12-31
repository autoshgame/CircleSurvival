using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[CreateAssetMenu(fileName ="SwordSkin", menuName ="Sword/Skin", order =2)]
public class SwordSkinSO : ScriptableObject
{
    public SerializableDictionaryBase<SwordEnum, SwordProps> props;
}

[System.Serializable]
public class SwordProps
{
    public Sprite image;
    public Vector3 posCollider;
    public Vector2 offsetCollider;
    public Vector2 sizeCollider;
    public ResourceType type;
    public int coin;
}

public enum SwordEnum
{
    SWORD_1,
    SWORD_2,
    SWORD_3,
    SWORD_4,
    SWORD_5,
    SWORD_6,
    SWORD_7,
    SWORD_8,
    SWORD_9,
    SWORD_10,
}

public enum ResourceType
{
    Ads = 0,
    IAP, 
    Normal
}