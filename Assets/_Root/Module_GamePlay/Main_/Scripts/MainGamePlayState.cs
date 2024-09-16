using AutoShGame.Base.FSMState;
using AutoShGame.Base.Observer;
using UnityEngine;
using AutoShGame.Base.Modal;

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
        ObserverAutoSh.RegisterObserver(this);
    }

    public override void OnExit()
    {
        ObserverAutoSh.RemoveObserver(this);
    }

    private void OnDestroy()
    {
        ObserverAutoSh.RemoveObserver(this);
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
        else if (data.action == MainGamePlayTopicAction.PAUSE_GAME)
        {
            ModalTopic modalTopic = new ModalTopic();
            modalTopic.modalType = typeof(InGameSettingsModal);
            ObserverAutoSh.NotifyObservers(modalTopic);
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
    PAUSE_GAME
}

