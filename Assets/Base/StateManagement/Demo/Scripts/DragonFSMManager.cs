namespace AutoShGame.Base.FSMState
{
    public class DragonFSMManager : FSMManager
    {
        private FSMState dragonIdleState;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            DragonFSMComponent dragonFSMComponent = GetComponent<DragonFSMComponent>();
            DragonFSMDependency dependency = new DragonFSMDependency();

            dependency.component = dragonFSMComponent;

            dragonIdleState = GetComponent<DragonIdleState>();
            dragonIdleState.OnSetupDependency(dependency);
            dicState.Add(dragonIdleState.GetState(), dragonIdleState);

            ChangeState(DragonEvent.IDLE);
        }
    }

    public class DragonFSMDependency
    {
        public DragonFSMComponent component;
    }
}
