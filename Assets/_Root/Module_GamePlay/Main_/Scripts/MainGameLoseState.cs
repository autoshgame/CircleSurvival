using AutoShGame.Base.FSMState;
using UnityEngine;
using AutoShGame.Base.Modal;
using AutoShGame.Base.Observer;
using UnityEngine.SceneManagement;
using AutoShGame.Base.ServiceProvider;

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
        LoseModalData loseModalData = new LoseModalData();
        loseModalData.actionClickExit = ActionClickEndGame;
        ServiceProvider.Resolve<IModalService>().Push<LoseModal>().InitData(loseModalData).Show();
    }

    public void ActionClickEndGame()
    {
        SceneManager.LoadScene("Home");
    }
}
