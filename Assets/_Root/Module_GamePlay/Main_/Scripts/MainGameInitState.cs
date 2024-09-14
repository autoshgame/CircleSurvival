using AutoShGame.Base.FSMState;
using AutoShGame.Base.Observer;

public class MainGameInitState : FSMState
{
    private MainGameFSMDependency dependency;

    public override string GetState()
    {
        return MainGameEvent.INIT;
    }

    public override void OnSetupDependency<T>(T args)
    {
        dependency = args as MainGameFSMDependency;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        //Init event for button
        dependency.component.pauseSettingButton.onClick.AddListener(OnSetUpSettingButton);

        //Init data player

        dependency.component.botTest.OnRequestTargerTransform(dependency.component.playerFSMComponent.playerRigidbody2D.transform);
        dependency.component.botTest.OnRequestPlayerFSM(dependency.component.playerFSMComponent);
        dependency.component.botTest.Init();

        dependency.component.mainCamFollowPlayer.TargetFollow = dependency.component.playerFSMComponent.playerRigidbody2D.transform;
        dependency.component.mainCamFollowPlayer.SetFollowStatus(true);

        dependency.component.botTest.StartSpawnBot();
        dependency.component.manager.ChangeState(MainGameEvent.PLAY);
    }

    void OnSetUpSettingButton()
    {
        MainGamePlayTopic mainGamePlayTopic = new MainGamePlayTopic();
        mainGamePlayTopic.action = MainGamePlayTopicAction.PAUSE_GAME;
        Observer.Instance.NotifyObservers(mainGamePlayTopic);
    }
}
