using UnityEngine;

public interface IWeaponNotify 
{
    public void OnNotify(WeaponNotifyMesssage messsage);
}

public enum WeaponNotifyMesssage
{
    COLLIDE,
    KILL_ENEMY,
}
