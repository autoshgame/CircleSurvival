using AutoShGame.Base.FSMState;
using UnityEngine;
using AutoShGame.Base.Modal;
using AutoShGame.Base.Observer;
using UnityEngine.SceneManagement;

public class MainGameLoseState : FSMState
{
    private MainGameFSMDependency dependency;

    public override string GetState()
    {
        return MainGameEvent.LOSE;
    }

    public override void OnSetupDependency<T>(T args)
    {
        dependency = args as MainGameFSMDependency;
    }

    public override void OnEnter()
    {
        dependency.component.playerFSMComponent.manager.gameObject.SetActive(false);
        LoseModalData loseModalData = new LoseModalData();
        loseModalData.actionClickExit = ActionClickEndGame;
        ModalManager.Instance.Push<LoseModal>().InitData(loseModalData).Show();
    }

    public void ActionClickEndGame()
    {
        SceneManager.LoadScene("Home");
    }
}
