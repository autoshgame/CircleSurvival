using AutoShGame.Base.FSMState;
using AutoShGame.Base.Observer;
using UnityEngine;
using AutoShGame.Base.Popup;
using UnityEngine.SceneManagement;


namespace CircleSurvival.Module.HomeMenu
{
    public class HomeViewState : FSMState, IObservableAutoSh<HomeViewStateTopic>
    {
        private HomeFSMDependency dependency;

        private void OnDestroy()
        {
            Observer.Instance?.RemoveObserver(this);
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
            Observer.Instance?.RegisterObserver(this);
        }

        public override void OnExit()
        {
            Observer.Instance?.RemoveObserver(this);
        }

        public void OnObserverNotify(HomeViewStateTopic data)
        {
            Debug.Log(data.action);

            switch (data.action)
            {
                case HomeViewStateAction.OPEN_SETTINGS:
                    Debug.Log("OPEN SETTINGS");
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
        public string action;
    }

    public static class HomeViewStateAction
    {
        public const string OPEN_SETTINGS = "OPEN_SETTINGS";
        public const string PLAY_GAME = "PLAY_GAME";
        public const string OPEN_SHOP = "OPEN_SHOP";
        public const string EXIT_GAME = "EXIT_GAME";
    }
}
