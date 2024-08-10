using UnityEngine;

public class BotOutSystemDetection : MonoBehaviour, IDamageable, IWeaponNotify
{
    [SerializeField] private BotFSMComponent botFSMComponent;

    public void OnNotify(WeaponNotifyMesssage messsage)
    {
        if (messsage == WeaponNotifyMesssage.KILL_ENEMY)
        {
            botFSMComponent.botStat.IncreaseLevel();
        }
    }

    public void TakeDamage(float damage)
    {
        botFSMComponent.manager.ChangeState(BotEvent.DEAD);
    }
}
