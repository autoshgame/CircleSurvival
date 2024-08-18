using AutoShGame.Base.FSMState;
using UnityEngine;
using AutoShGame.Base.Modal;
using AutoShGame.Base.Observer;
using UnityEngine.SceneManagement;

public class MainGameLoseState : FSMState, IObservableAutoSh<LoseModalActionTopic>
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
        Observer.Instance.RegisterObserver(this);

        dependency.component.playerFSMComponent.manager.gameObject.SetActive(false);
        ModalManager.Instance.Push<LoseModal>().Show();
    }

    public override void OnExit()
    {
        Observer.Instance?.RemoveObserver(this);
    }

    private void OnDestroy()
    {
        Observer.Instance?.RemoveObserver(this);
    }

    public void OnObserverNotify(LoseModalActionTopic data)
    {
        if (data.actionLoseModal == ActionLoseModal.CLOSE)
        {
            SceneManager.LoadScene("Home");
        }
    }

}
