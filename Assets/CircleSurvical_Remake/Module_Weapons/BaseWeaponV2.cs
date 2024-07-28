using UnityEngine;

public abstract class BaseWeaponV2 : MonoBehaviour
{
    public abstract void Init<T>(T args);

    public abstract void SetLevel(int level);

    public abstract void SetStatus(bool status);
}
