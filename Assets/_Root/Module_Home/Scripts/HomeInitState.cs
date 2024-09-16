using AutoShGame.Base.FSMState;
using UnityEngine;
using AutoShGame.Base.Observer;


namespace CircleSurvival.Module.HomeMenu
{
    public class HomeInitState : FSMState
    {
        private HomeFSMDependency dependency;

        public override string GetState()
        {
            return HomeEvent.INIT;
        }

        public override void OnSetupDependency<T>(T args)
        {
            dependency = args as HomeFSMDependency;
        }

        public override void OnEnter()
        {
            dependency.component.homeBGSoundController.PlaySound();
            dependency.component.buttonSettings.onClick.AddListener(OnSetupListenerSettingsButton);
            dependency.component.buttonPlayGame.onClick.AddListener(OnSetupListenerPlayGameButton);
            dependency.component.buttonShop.onClick.AddListener(OnSetupListenerOpenShopButton);
            dependency.component.buttonExitGame.onClick.AddListener(OnSetupListenerExitGameButton);
            dependency.component.manager.ChangeState(HomeEvent.HOME_VIEW);        
        }

        private void OnSetupListenerSettingsButton()
        {
            HomeViewStateTopic homeViewStateTopic = new HomeViewStateTopic();
            homeViewStateTopic.action = HomeViewStateAction.OPEN_SETTINGS;
            ObserverAutoSh.NotifyObservers(homeViewStateTopic);
        }

        private void OnSetupListenerPlayGameButton()
        {
            HomeViewStateTopic homeViewStateTopic = new HomeViewStateTopic();
            homeViewStateTopic.action = HomeViewStateAction.PLAY_GAME;
            ObserverAutoSh.NotifyObservers(homeViewStateTopic);
        }

        private void OnSetupListenerOpenShopButton()
        {
            HomeViewStateTopic homeViewStateTopic = new HomeViewStateTopic();
            homeViewStateTopic.action = HomeViewStateAction.OPEN_SHOP;
            ObserverAutoSh.NotifyObservers(homeViewStateTopic);
        }

        private void OnSetupListenerExitGameButton()
        {
            HomeViewStateTopic homeViewStateTopic = new HomeViewStateTopic();
            homeViewStateTopic.action = HomeViewStateAction.EXIT_GAME;
            ObserverAutoSh.NotifyObservers(homeViewStateTopic);
        }
    }
}
