using AutoShGame.Base.FSMState;

public class BotUpdateLevelState : FSMState
{
    private BotFSMDependency dependency;

    public override string GetState()
    {
        return BotEvent.UPGRADE;
    }

    public override void OnSetupDependency<T>(T args)
    {
        dependency = args as BotFSMDependency;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        dependency.component.txtLevel.text = dependency.component.botStat.level.ToString();
        dependency.component.weapon.SetLevel(dependency.component.botStat.level);
        dependency.component.manager.ChangeState(BotEvent.IDLE);
    }
}
