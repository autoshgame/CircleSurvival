using AutoShGame.Base.FSMState;
using UnityEngine;

public class MainGameFSMManager : FSMManager
{
    private FSMState mainGameInitState;
    private FSMState mainGamePlayState;

    protected override void Awake()
    {
        base.Awake();

        MainGameFSMDependency dependency = new MainGameFSMDependency();
        dependency.component = GetComponent<MainGameFSMComponent>();

        mainGameInitState = GetComponent<MainGameInitState>();
        mainGameInitState.OnSetupDependency(dependency);
        dicState.Add(mainGameInitState.GetState(), mainGameInitState);

        mainGamePlayState = GetComponent<MainGamePlayState>();
        dicState.Add(mainGamePlayState.GetState(), mainGamePlayState);
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