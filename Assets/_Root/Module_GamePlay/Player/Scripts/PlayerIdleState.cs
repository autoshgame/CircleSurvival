using UnityEngine;
using AutoShGame.Base.FSMState;

public class PlayerIdleState : FSMState
{
    public override string GetState()
    {
        return PlayerState.IDLE;
    }

    public override void OnSetupDependency<T>(T args)
    {
        
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }
}
