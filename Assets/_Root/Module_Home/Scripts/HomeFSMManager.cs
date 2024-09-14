using UnityEngine;
using AutoShGame.Base.FSMState;

namespace CircleSurvival.Module.HomeMenu
{
    public class HomeFSMManager : FSMManager
    {
        private FSMState homeViewState;
        private FSMState homeInitState;

        private void Start()
        {
            HomeFSMComponent homeFSMComponent = GetComponent<HomeFSMComponent>();

            HomeFSMDependency homeFSMDependency = new HomeFSMDependency();
            homeFSMDependency.component = homeFSMComponent;

            homeInitState = GetComponent<HomeInitState>();
            homeInitState.OnSetupDependency(homeFSMDependency);
            dicState.Add(homeInitState.GetState(), homeInitState);

            homeViewState = GetComponent<HomeViewState>();
            homeViewState.OnSetupDependency(homeFSMDependency);
            dicState.Add(homeViewState.GetState(), homeViewState);

            ChangeState(HomeEvent.INIT);
        }
    }

    public class HomeFSMDependency
    {
        public HomeFSMComponent component;
    }
}
