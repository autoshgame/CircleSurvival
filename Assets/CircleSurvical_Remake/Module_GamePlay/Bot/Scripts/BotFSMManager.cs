using AutoShGame.Base.FSMState;

public class BotFSMManager : FSMManager
{
    private FSMState botInitState;
    private FSMState botIdleState;
    private FSMState botMovingState;
    private FSMState botDeadState;
    private FSMState botReviveState;

    protected override void Awake()
    {
        base.Awake();

        BotFSMComponent botFSMComponent = GetComponent<BotFSMComponent>();
        BotFSMDependency dependency = new BotFSMDependency();
        dependency.component = botFSMComponent;

        botInitState = GetComponent<BotInitState>();
        botInitState.OnSetupDependency(dependency);
        dicState.Add(botInitState.GetState(), botInitState);

        botIdleState = GetComponent<BotIdleState>();
        dicState.Add(botIdleState.GetState(), botIdleState);

        botDeadState = GetComponent<BotDeadState>();
        botDeadState.OnSetupDependency(dependency);
        dicState.Add(botDeadState.GetState(), botDeadState);

        botReviveState = GetComponent<BotReviveState>();
        botReviveState.OnSetupDependency(dependency);
        dicState.Add(botReviveState.GetState(), botReviveState);

        dependency.component = botFSMComponent;
    }

    private void Start()
    {
        ChangeState(BotEvent.INIT);
    }
}

public class BotFSMDependency
{
    public BotFSMComponent component;
}
