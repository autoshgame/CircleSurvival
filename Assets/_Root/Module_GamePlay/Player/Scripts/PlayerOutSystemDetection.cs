using UnityEngine;

public class PlayerOutSystemDetection : MonoBehaviour, IDamageable, IWeaponNotify
{
    [SerializeField] private PlayerFSMComponent component;

    public void OnNotify(WeaponNotifyMesssage messsage)
    {
        if (messsage == WeaponNotifyMesssage.KILL_ENEMY)
        {
            component.stat.IncreaseLevel();
        }
    }

    public void TakeDamage(float damage)
    {
        component.manager.ChangeState(PlayerState.DEAD);
    }
}
