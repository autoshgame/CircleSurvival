using UnityEngine;

namespace AutoShGame.Base.FSMState
{
    public class DragonIdleState : FSMState
    {
        private DragonFSMDependency dependency;

        public override string GetState()
        {
            return DragonEvent.IDLE;
        }

        public override void OnSetupDependency<T>(T args)
        {
            dependency = args as DragonFSMDependency;
        }

        public override void OnEnter()
        {
            Debug.Log($"Dragon enter idle state with object {dependency.component.mockComponent}");
        }
    }
}
