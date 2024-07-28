using System.Collections;
using UnityEngine;
using AutoShGame.Base.Observer;

public class PlayerStat : MonoBehaviour
{
    private PlayerFSMComponent playerFSMComponent;

    public int level;

    private void Awake()
    {
        playerFSMComponent = GetComponent<PlayerFSMComponent>();    
    }

    public void Init()
    {
        level = 0;
    }

    public void IncreaseLevel()
    {
        level++;
        playerFSMComponent.manager.ChangeState(PlayerState.UPGRADE);

        PlayerUpdateLevelChannel playerUpdateLevelChannel = new PlayerUpdateLevelChannel();
        playerUpdateLevelChannel.level = level;
        Observer.Instance?.NotifyObservers(playerUpdateLevelChannel);
    }
}
