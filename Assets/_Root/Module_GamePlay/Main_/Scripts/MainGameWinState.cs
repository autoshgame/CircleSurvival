using AutoShGame.Base.FSMState;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using AutoShGame.Base.Observer;
using AutoShGame.Base.ServiceProvider;


public class MainGameWinState : FSMState
{
    private MainGameFSMDependency mainGameFSMDependency;

    private int coinForWinState = 20;
    private bool isLoadCurrencyDataSuccess;
    private bool isUpdateCurrencyDataSuccess;

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
        //mainGameFSMDependency.component.playerFSMComponent.manager.gameObject.SetActive(false);

        mainGameFSMDependency.component.playerFSMComponent.playerRigidbody2D.transform.localScale = Vector3.zero;
        mainGameFSMDependency.component.playerFSMComponent.weapon.SetStatus(false);
        mainGameFSMDependency.component.playerFSMComponent.weapon.transform.localScale = Vector3.zero;

        PlayerData playerData = ServiceProvider.Resolve<IDataService>().GetUserData();
        playerData.currency.coin += coinForWinState;
        ServiceProvider.Resolve<IDataService>().SaveUserData(playerData);

        WinModalData winModalData = new WinModalData();
        winModalData.actionExit = Exit;
        winModalData.actionReplay = Replay;
        winModalData.coinReceived = coinForWinState;

        ServiceProvider.Resolve<IModalService>().Push<WinModal>().InitData(winModalData).Show();
    }

    private void Exit()
    {
        SceneManager.LoadScene("Home");
    }

    private void Replay()
    {
        SceneManager.LoadScene("_MainGamePlay");
    }
}
