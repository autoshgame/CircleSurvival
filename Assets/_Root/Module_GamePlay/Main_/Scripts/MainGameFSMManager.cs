using AutoShGame.Base.FSMState;
using UnityEngine;

public class MainGameFSMManager : FSMManager
{
    private FSMState mainGameInitState;
    private FSMState mainGamePlayState;
    private FSMState mainGameWinState;
    private FSMState mainGameLoseState;

    protected override void Awake()
    {
        base.Awake();

        MainGameFSMDependency dependency = new MainGameFSMDependency();
        dependency.component = GetComponent<MainGameFSMComponent>();

        mainGameInitState = GetComponent<MainGameInitState>();
        mainGameInitState.OnSetupDependency(dependency);
        dicState.Add(mainGameInitState.GetState(), mainGameInitState);

        mainGamePlayState = GetComponent<MainGamePlayState>();
        mainGamePlayState.OnSetupDependency(dependency);
        dicState.Add(mainGamePlayState.GetState(), mainGamePlayState);

        mainGameWinState = GetComponent<MainGameWinState>();
        mainGameWinState.OnSetupDependency(dependency);
        dicState.Add(mainGameWinState.GetState(), mainGameWinState);

        mainGameLoseState = GetComponent<MainGameLoseState>();
        mainGameLoseState.OnSetupDependency(dependency);
        dicState.Add(mainGameLoseState.GetState(), mainGameLoseState);
    }

    private void Start()
    {
        ChangeState(MainGameEvent.INIT);
    }
}

[System.Serializable]
public class MainGameFSMDependency
{
    public MainGameFSMComponent component;
}