using AutoShGame.Base.FSMState;
using UnityEngine;
using AutoShGame.Base.Modal;
using UnityEngine.SceneManagement;
using System.Collections;
using AutoShGame.Base.Observer;

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

        StartCoroutine(UpdatePlayerCurrency());
    }

    IEnumerator UpdatePlayerCurrency()
    {
        //Load currency data (coin)
        CurrencyData currencyData = new CurrencyData();

        CurrencyDataTopic testGameDataTopic = new CurrencyDataTopic();
        testGameDataTopic.result = (value) => {
            currencyData = value;
        };

        testGameDataTopic.actionType = ActionType.GET;
        testGameDataTopic.onLoadSuccess = (value) => { isLoadCurrencyDataSuccess = value; };
        Observer.Instance.NotifyObservers(testGameDataTopic);
        //end load currency data

        yield return new WaitUntil(() => isLoadCurrencyDataSuccess);
        currencyData.coin += coinForWinState;

        //Update currency data (coin)
        CurrencyDataTopic topic = new CurrencyDataTopic();
        topic.actionType = ActionType.UPDATE;
        topic.updateData = currencyData;
        topic.onLoadSuccess = (value) => isUpdateCurrencyDataSuccess = value;
        Observer.Instance.NotifyObservers(topic);

        yield return new WaitUntil(() => isUpdateCurrencyDataSuccess);
        //end Update currency data

        WinModalData winModalData = new WinModalData();
        winModalData.actionExit = Exit;
        winModalData.actionReplay = Replay;
        winModalData.coinReceived = coinForWinState;
        ModalManager.Instance.Push<WinModal>().InitData(winModalData).Show();
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
