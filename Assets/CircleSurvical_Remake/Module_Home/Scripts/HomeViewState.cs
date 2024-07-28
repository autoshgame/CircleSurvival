using AutoShGame.Base.FSMState;
using AutoShGame.Base.Observer;
using UnityEngine;
using AutoShGame.Base.Popup;

namespace CircleSurvival.Module.HomeMenu
{
    public class HomeViewState : FSMState, IObserver<HomeViewStateChannel>
    {
        private void OnDestroy()
        {
            Observer.Instance?.RemoveObserver(this);
        }

        public override void OnSetupDependency<T>(T args)
        {
            
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

        public void OnObserverNotify(HomeViewStateChannel data)
        {
            Debug.Log(data.action);

            switch (data.action)
            {
                case HomeViewStateAction.OPEN_SETTINGS:
                    Debug.Log("OPEN SETTINGS");
                    break;
                case HomeViewStateAction.PLAY_GAME:
                    Debug.Log("PLAY GAME");
                    break;
                case HomeViewStateAction.OPEN_SHOP:
                    Debug.Log("OPEN SHOP");
                    break;
                case HomeViewStateAction.EXIT_GAME:
                    Application.Quit();
                    break;
            }
        }
    }

    public class HomeViewStateChannel
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
