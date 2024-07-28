using UnityEngine;

namespace AutoShGame.Base.FSMState
{
    public abstract class FSMDecision : MonoBehaviour
    {
        public abstract bool Decide(string state);
    }
}
