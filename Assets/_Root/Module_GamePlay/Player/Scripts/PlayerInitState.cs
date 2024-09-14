using AutoShGame.Base.FSMState;
using AutoShGame.Base.Observer;
using System.Collections;
using UnityEngine;

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

        StartCoroutine(LoadUserDataAndInitComponent());
    }

    IEnumerator LoadUserDataAndInitComponent()
    {
        SwordEnum userSwordData = SwordEnum.SWORD_1;

        //Load skin data
        SkinDataTopic skinDataTopic = new SkinDataTopic();
        skinDataTopic.result = (value) => {
            userSwordData = value.choosenSword;
        };

        skinDataTopic.actionType = ActionType.GET;
        skinDataTopic.onLoadSuccess = (value) => { isLoadSkinDataSuccess = value; };
        Observer.Instance.NotifyObservers(skinDataTopic);
        //end load skin data

        yield return new WaitUntil(() => isLoadSkinDataSuccess);
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
