using AutoShGame.Base.FSMState;
using UnityEngine;
using AutoShGame.Base.Observer;

namespace CircleSurvival.Module.HomeMenu
{
    public class HomeInitState : FSMState
    {
        [SerializeField] private AudioClip audioBackground;

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
            AutoShGame.Base.Sound.SoundManager.Instance.PlayBySource(audioBackground);
            dependency.component.buttonSettings.onClick.AddListener(OnSetupListenerSettingsButton);
            dependency.component.buttonPlayGame.onClick.AddListener(OnSetupListenerPlayGameButton);
            dependency.component.buttonShop.onClick.AddListener(OnSetupListenerOpenShopButton);
            dependency.component.buttonExitGame.onClick.AddListener(OnSetupListenerExitGameButton);
            dependency.component.manager.ChangeState(HomeEvent.HOME_VIEW);        
        }

        private void OnSetupListenerSettingsButton()
        {
            HomeViewStateChannel homeViewStateChannel = new HomeViewStateChannel();
            homeViewStateChannel.action = HomeViewStateAction.OPEN_SETTINGS;
            Observer.Instance?.NotifyObservers(homeViewStateChannel);
        }

        private void OnSetupListenerPlayGameButton()
        {
            HomeViewStateChannel homeViewStateChannel = new HomeViewStateChannel();
            homeViewStateChannel.action = HomeViewStateAction.PLAY_GAME;
            Observer.Instance?.NotifyObservers(homeViewStateChannel);
        }

        private void OnSetupListenerOpenShopButton()
        {
            HomeViewStateChannel homeViewStateChannel = new HomeViewStateChannel();
            homeViewStateChannel.action = "OPEN_SHOP";
            Observer.Instance?.NotifyObservers(homeViewStateChannel);
        }

        private void OnSetupListenerExitGameButton()
        {
            HomeViewStateChannel homeViewStateChannel = new HomeViewStateChannel();
            homeViewStateChannel.action = "EXIT_GAME";
            Observer.Instance?.NotifyObservers(homeViewStateChannel);
        }
    }
}
