using AutoShGame.Base.FSMState;

public class BotIdleState : FSMState
{
    public override string GetState()
    {
        return BotEvent.IDLE;
    }

    public override void OnSetupDependency<T>(T args)
    {
        
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }
}
