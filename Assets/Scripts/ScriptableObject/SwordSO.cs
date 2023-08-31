using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[CreateAssetMenu(fileName ="SwordStat", menuName ="Sword/Stat", order = 1)]
public class SwordSO : ScriptableObject
{
    public SerializableDictionaryBase<int, SwordPropertiesSO> props;
}

[System.Serializable]
public class SwordPropertiesSO
{
    public float rotateSpeed;
    public Vector3 scale;
}
