using AutoShGame.Base.FSMState;
using AutoShGame.Base.Observer;
using UnityEngine;
using AutoShGame.Base.ServiceProvider;

public class PlayerInitState : FSMState
{
    private PlayerFSMDependency playerFSMDependency;
    private bool isLoadSkinDataSuccess;

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

        LoadUserDataAndInitComponent();
    }

    void LoadUserDataAndInitComponent()
    {
        SwordEnum userSwordData = SwordEnum.SWORD_1;

        userSwordData = ServiceProvider.Resolve<IDataService>().GetUserData().weapon.currentSword;

        SwordV2Data swordV2Data = new SwordV2Data();
        swordV2Data.sword = userSwordData;
        swordV2Data.parents = playerFSMDependency.component.playerRigidbody2D.gameObject.transform;
        swordV2Data.currentLevel = playerFSMDependency.component.stat.level;
        swordV2Data.notify = playerFSMDependency.component.playerOutSystemDetection;

        playerFSMDependency.component.movement.CanMove = true;
        playerFSMDependency.component.stat.Init();
        playerFSMDependency.component.weapon.Init(swordV2Data);
        playerFSMDependency.component.manager.ChangeState(PlayerState.IDLE);
    }
}

public class PlayerInitStateData
{

}
