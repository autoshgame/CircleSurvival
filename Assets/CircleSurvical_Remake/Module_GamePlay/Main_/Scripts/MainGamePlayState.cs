using AutoShGame.Base.FSMState;
using AutoShGame.Base.Observer;
using UnityEngine;

public class MainGamePlayState : FSMState, IObservableAutoSh<PlayerDeadStateChannel>
{
    public override string GetState()
    {
        return MainGameEvent.PLAY;
    }

    public override void OnSetupDependency<T>(T args)
    {
        throw new System.NotImplementedException();
    }

    public override void OnEnter()
    {
        Observer.Instance?.RegisterObserver(this);
        base.OnEnter();
    }

    public override void OnExit()
    {
        Observer.Instance?.RemoveObserver(this);
        base.OnExit();
    }

    private void OnDestroy()
    {
        Observer.Instance?.RemoveObserver(this);
    }

    public void OnObserverNotify(PlayerDeadStateChannel data)
    {
        Debug.Log("U ARE DEAD");
    }
}
