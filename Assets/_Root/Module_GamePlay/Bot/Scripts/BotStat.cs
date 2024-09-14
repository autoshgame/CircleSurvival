using UnityEngine;

public class BotStat : MonoBehaviour
{
    [SerializeField] private BotFSMComponent botFSMComponent;

    public int level;

    public void Init()
    {
        level = 0;
    }

    public void IncreaseLevel()
    {
        level++;
        botFSMComponent.manager.ChangeState(BotEvent.UPGRADE);
    }
}
