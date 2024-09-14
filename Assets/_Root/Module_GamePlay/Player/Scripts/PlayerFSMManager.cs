using AutoShGame.Base.FSMState;
using UnityEngine;

public class PlayerFSMManager : FSMManager
{
    private FSMState playerInitState;
    private FSMState playerIdleState;
    private FSMState playerMovingState;
    private FSMState playerUpdateLevelState;
    private FSMState playerDeadState;

    protected override void Awake()
    {
        base.Awake();

        PlayerFSMComponent homeFSMComponent = GetComponent<PlayerFSMComponent>();

        PlayerFSMDependency playerFSMDependency = new PlayerFSMDependency();
        playerFSMDependency.component = homeFSMComponent;

        playerInitState = GetComponent<PlayerInitState>();
        dicState.Add(playerInitState.GetState(), playerInitState);
        playerInitState.OnSetupDependency(playerFSMDependency);

        playerIdleState = GetComponent<PlayerIdleState>();
        dicState.Add(playerIdleState.GetState(), playerIdleState);

        playerMovingState = GetComponent<PlayerMovingState>();
        dicState.Add(playerMovingState.GetState(), playerMovingState);

        playerUpdateLevelState = GetComponent<PlayerUpdateLevelState>();
        playerUpdateLevelState.OnSetupDependency(playerFSMDependency);
        dicState.Add(playerUpdateLevelState.GetState(), playerUpdateLevelState);

        playerDeadState = GetComponent<PlayerDeadState>();
        playerDeadState.OnSetupDependency(playerFSMDependency);
        dicState.Add(playerDeadState.GetState(), playerDeadState);
    }

    private void Start()
    {
        ChangeState(PlayerState.INIT);
    }

}

public class PlayerFSMDependency
{
    public PlayerFSMComponent component;
}
