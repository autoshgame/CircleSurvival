using AutoShGame.Base.FSMState;
using AutoShGame.Base.Observer;
using UnityEngine;

public class BotReviveState : FSMState
{
    private BotReviveStateData botReviveStateData;
    private BotFSMDependency dependency;

    public override string GetState()
    {
        return BotEvent.REVIVE;
    }

    public override void OnSetupDependency<T>(T args)
    {
        dependency = args as BotFSMDependency;
    }

    public override void OnEnter(object data)
    {
        base.OnEnter(data);

        if (data is BotReviveStateData)
        {
            /*
            BotReviveStateChannel botReviveStateChannel = new BotReviveStateChannel();
            botReviveStateChannel.aliveBot = dependency.component.manager;
            Observer.Instance.NotifyObservers(botReviveStateChannel);
            */

            botReviveStateData = data as BotReviveStateData;

            dependency.component.manager.transform.localScale = Vector3.zero;

            dependency.component.botRigidbody2D.gameObject.SetActive(true);
            dependency.component.weapon.gameObject.SetActive(true);
            dependency.component.weapon.SetLevel(botReviveStateData.levelRevive);
            dependency.component.weapon.SetStatus(true);
            dependency.component.botRigidbody2D.gameObject.transform.position = botReviveStateData.positionSpawn;
            dependency.component.weapon.transform.position = dependency.component.botRigidbody2D.gameObject.transform.position;

            dependency.component.manager.transform.localScale = Vector3.one;


            dependency.component.manager.ChangeState(BotEvent.IDLE);
        }
    }
}


[System.Serializable]
public class BotReviveStateData
{
    public int levelRevive;
    public SwordEnum swordSkin;
    public Vector3 positionSpawn;
}

[System.Serializable]
public class BotReviveStateChannel
{
    public BotFSMManager aliveBot;
}

