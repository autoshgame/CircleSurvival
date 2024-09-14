using AutoShGame.Base.FSMState;
using AutoShGame.Base.Sound;
using AutoShGame.Base.Observer;

public class PlayerUpdateLevelState : FSMState
{
    private PlayerFSMDependency dependency;

    public override string GetState()
    {
        return PlayerState.UPGRADE;
    }

    public override void OnSetupDependency<T>(T args)
    {
        dependency = args as PlayerFSMDependency;
    }

    public override void OnEnter()
    {
        dependency.component.txtLevel.text = dependency.component.stat.level.ToString();
        dependency.component.weapon.SetLevel(dependency.component.stat.level);
        dependency.component.manager.ChangeState(PlayerState.IDLE);
        SoundTopic soundTopic = new SoundTopic(dependency.component.audioUpgradeLevel, SourceConfigType.TwoD);
        Observer.Instance.NotifyObservers(soundTopic);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}

public class PlayerUpdateLevelTopic
{
    public int level;
}
