using AutoShGame.Base.FSMState;
using UnityEngine;

public class MainGameLoseState : FSMState
{
    private MainGameFSMDependency dependency;

    public override string GetState()
    {
        return MainGameEvent.LOSE;
    }

    public override void OnSetupDependency<T>(T args)
    {
        dependency = args as MainGameFSMDependency;
    }

    public override void OnEnter()
    {
        //Show component revive

        dependency.component.playerFSMComponent.manager.gameObject.SetActive(false);

        Time.timeScale = 0;
    }
}
