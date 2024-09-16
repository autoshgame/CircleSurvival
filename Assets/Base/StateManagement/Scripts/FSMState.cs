using UnityEngine;

namespace AutoShGame.Base.FSMState
{
    public abstract class FSMState : MonoBehaviour
    {
        public abstract void OnSetupDependency<T>(T args);

        public abstract string GetState();

        public virtual void OnEnter() { }

        public virtual void OnEnter(object data = null) { }

        public virtual void OnExit() { }
    }
}
