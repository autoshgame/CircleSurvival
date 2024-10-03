using AutoShGame.Base.FSMState;
using AutoShGame.Base.Observer;
using UnityEngine;
using UnityEngine.SceneManagement;
using AutoShGame.Base.ServiceProvider;


namespace CircleSurvival.Module.HomeMenu
{
    public class HomeViewState : FSMState, IObservableAutoSh<HomeViewStateTopic>
    {
        private HomeFSMDependency dependency;

        private void OnDestroy()
        {
            ObserverAutoSh.RemoveObserver(this);
        }

        public override void OnSetupDependency<T>(T args)
        {
            dependency = args as HomeFSMDependency;
        }

        public override string GetState()
        {
            return HomeEvent.HOME_VIEW;
        }

        public override void OnEnter()
        {
            ObserverAutoSh.RegisterObserver(this);
        }

        public override void OnExit()
        {
            ObserverAutoSh.RemoveObserver(this);
        }

        public void OnObserverNotify(HomeViewStateTopic data)
        {
            Debug.Log(data.action);

            switch (data.action)
            {
                case HomeViewStateAction.OPEN_SETTINGS:
                    ServiceProvider.Resolve<IModalService>().Push<SettingsModal>().Show();
                    break;
                case HomeViewStateAction.PLAY_GAME:
                    SceneManager.LoadScene("_MainGamePlay");
                    Debug.Log("PLAY GAME");
                    break;
                case HomeViewStateAction.OPEN_SHOP:
                    dependency.component.shopComponent.manager.gameObject.SetActive(true);
                    dependency.component.shopComponent.manager.ChangeState(ShopEvent.INIT);
                    break;
                case HomeViewStateAction.EXIT_GAME:
                    Application.Quit();
                    break;
            }
        }
    }

    public class HomeViewStateTopic
    {
        public HomeViewStateAction action;
    }

    public enum HomeViewStateAction
    {
        OPEN_SETTINGS,
        PLAY_GAME,
        OPEN_SHOP,
        EXIT_GAME
    }
}
