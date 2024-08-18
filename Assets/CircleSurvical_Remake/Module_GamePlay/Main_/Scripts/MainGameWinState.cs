using AutoShGame.Base.FSMState;
using UnityEngine;

public class MainGameWinState : FSMState
{
    private MainGameFSMDependency mainGameFSMDependency;

    public override string GetState()
    {
        return MainGameEvent.WIN;
    }

    public override void OnSetupDependency<T>(T args)
    {
        mainGameFSMDependency = args as MainGameFSMDependency;
    }

    public override void OnEnter()
    {
        mainGameFSMDependency.component.playerFSMComponent.manager.gameObject.SetActive(false);
        Time.timeScale = 0;
    }
}
