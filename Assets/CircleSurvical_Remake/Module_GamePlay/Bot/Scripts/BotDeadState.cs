using AutoShGame.Base.FSMState;
using UnityEngine;
using AutoShGame.Base.Observer;

public class BotDeadState : FSMState
{
    private BotFSMDependency dependency;

    public override string GetState()
    {
        return BotEvent.DEAD;
    }

    public override void OnSetupDependency<T>(T args)
    {
        dependency = args as BotFSMDependency;
    }

    public override void OnEnter()
    {
        dependency.component.botRigidbody2D.gameObject.SetActive(false);
        dependency.component.weapon.gameObject.SetActive(false);

        BotDeadStateChannel botDeadStateChannel = new BotDeadStateChannel();
        botDeadStateChannel.deadBot = dependency.component.manager;
        Observer.Instance.NotifyObservers(botDeadStateChannel);
    }
}

[System.Serializable]
public class BotDeadStateChannel
{
    public BotFSMManager deadBot; 
}
