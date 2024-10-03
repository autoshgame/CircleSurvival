using UnityEngine;
using AutoShGame.Base.Observer;

public class PlayerStat : MonoBehaviour
{
    //Refactor
    private PlayerFSMComponent playerFSMComponent;

    public int level;

    private void Awake()
    {
        //Refactor
        playerFSMComponent = GetComponent<PlayerFSMComponent>();    
    }

    public void Init()
    {
        level = 0;
    }

    public void IncreaseLevel()
    { 
        //Refactor
        level++;
        playerFSMComponent.manager.ChangeState(PlayerState.UPGRADE);

        PlayerUpdateLevelTopic playerUpdateLevelTopic = new PlayerUpdateLevelTopic();
        playerUpdateLevelTopic.level = level;
        ObserverAutoSh.NotifyObservers(playerUpdateLevelTopic);
    }
}
