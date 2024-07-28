using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoShGame.Base.FSMState
{
    /// <summary>
    /// Base class for every FSMState Management 
    /// <br></br>
    /// <br></br>
    /// Implements samples : Demo Scene
    /// </summary>
    public class FSMManager : MonoBehaviour
    {
        private FSMState currentState;
        public FSMState CurrentState { get => currentState; }

        private FSMDecision decision;

        protected Dictionary<string, FSMState> dicState = new Dictionary<string, FSMState>();

        protected virtual void Awake()
        {
            decision = GetComponent<FSMDecision>();    
        }

        private void Update()
        {
            if (currentState != null) currentState.OnUpdate();
        }

        private void FixedUpdate()
        {
            if (currentState != null) currentState.OnFixedUpdate();
        }

        public void ChangeState(string state, object data = null)
        {
            if (!dicState.ContainsKey(state))
            {
                Debug.LogError($"DIC STATE DO NOT CONTAIN : {state}");
                return;
            }

            FSMState nextState = dicState[state];

            if (currentState != null)
            {
                if (currentState.GetState() == state) return;

                bool canEnterState = true;

                if (decision != null) canEnterState = decision.Decide(state);
                if (canEnterState == false) return;

                currentState.OnExit();
                currentState = nextState;

                if (data != null) currentState.OnEnter(data);
                else currentState.OnEnter();
            }
            else
            {
                currentState = nextState;

                if (data != null) currentState.OnEnter(data);
                else currentState.OnEnter();
            }
        }
    }


}
