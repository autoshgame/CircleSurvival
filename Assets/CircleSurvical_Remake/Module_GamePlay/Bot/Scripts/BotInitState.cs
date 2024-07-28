using UnityEngine;
using AutoShGame.Base.FSMState;

public class BotInitState : FSMState
{
    private BotFSMDependency dependency;

    public override string GetState()
    {
        return BotEvent.INIT;
    }

    public override void OnSetupDependency<T>(T args)
    {
        dependency = args as BotFSMDependency;
    }

    public override void OnEnter()
    {
        dependency.component.botMovement.CanMove = true;
        SwordV2Data swordV2Data = new SwordV2Data();
        swordV2Data.sword = SwordEnum.SWORD_1;
        swordV2Data.parents = dependency.component.botRigidbody2D.transform;
        swordV2Data.currentLevel = 1;
        dependency.component.weapon.Init(swordV2Data);
        dependency.component.manager.ChangeState(BotEvent.IDLE);
    }
}
