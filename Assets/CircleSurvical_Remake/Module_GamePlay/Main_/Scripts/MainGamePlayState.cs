using AutoShGame.Base.FSMState;
using AutoShGame.Base.Observer;
using UnityEngine;

public class MainGamePlayState : FSMState, IObservableAutoSh<MainGamePlayTopic>
{
    private MainGameFSMDependency dependency;

    public override string GetState()
    {
        return MainGameEvent.PLAY;
    }

    public override void OnSetupDependency<T>(T args)
    {
        dependency = args as MainGameFSMDependency;
    }

    public override void OnEnter()
    {
        Observer.Instance?.RegisterObserver(this);
    }

    public override void OnExit()
    {
        Observer.Instance?.RemoveObserver(this);
    }

    private void OnDestroy()
    {
        Observer.Instance?.RemoveObserver(this);
    }

    public void OnObserverNotify(MainGamePlayTopic data)
    {
        if (data.action == MainGamePlayTopicAction.WIN_GAME)
        {
            dependency.component.manager.ChangeState(MainGameEvent.WIN);
        }
        else if (data.action == MainGamePlayTopicAction.LOSE_GAME)
        {
            dependency.component.manager.ChangeState(MainGameEvent.LOSE);
        }
    }
}

[System.Serializable]
public class MainGamePlayTopic
{
    public MainGamePlayTopicAction action;
}

public enum MainGamePlayTopicAction
{
    WIN_GAME,
    LOSE_GAME,
}

