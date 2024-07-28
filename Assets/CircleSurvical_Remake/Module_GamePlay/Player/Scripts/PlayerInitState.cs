using AutoShGame.Base.FSMState;

public class PlayerInitState : FSMState
{
    private PlayerFSMDependency playerFSMDependency;

    public override string GetState()
    {
        return PlayerState.INIT;

    }

    public override void OnSetupDependency<T>(T args)
    {
        playerFSMDependency = args as PlayerFSMDependency;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        playerFSMDependency.component.movement.CanMove = true;
        playerFSMDependency.component.stat.Init();
        //playerFSMDependency.component.weapon.Ini

        SwordV2Data swordV2Data = new SwordV2Data();
        swordV2Data.sword = SwordEnum.SWORD_1;
        swordV2Data.parents = playerFSMDependency.component.playerRigidbody2D.gameObject.transform;
        swordV2Data.currentLevel = playerFSMDependency.component.stat.level;
        swordV2Data.notify = playerFSMDependency.component.playerOutSystemDetection;

        playerFSMDependency.component.weapon.Init(swordV2Data);
        playerFSMDependency.component.manager.ChangeState(PlayerState.IDLE);

    }
}

public class PlayerInitStateData
{

}
