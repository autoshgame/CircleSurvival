using UnityEngine;

public class BotOutSystemDetection : MonoBehaviour, IDamageable
{
    [SerializeField] private BotFSMComponent botFSMComponent;

    public void TakeDamage(float damage)
    {
        botFSMComponent.manager.ChangeState(BotEvent.DEAD);
    }
}
