using UnityEngine;
using AutoShGame.Base.FSMState;

public class PlayerMovingState : FSMState
{
    public override string GetState()
    {
        return PlayerState.MOVING;
    }

    public override void OnSetupDependency<T>(T args)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }
}
