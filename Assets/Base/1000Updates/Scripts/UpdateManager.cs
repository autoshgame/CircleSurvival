using System.Collections.Generic;
using UnityEngine;

namespace AutoShGame.Base.OneThousandUpdate
{
    [DefaultExecutionOrder(-99)]
    public class UpdateManager : MonoBehaviour
    {
        private List<IUpdateable> updatables = new List<IUpdateable>();

        public void RegisterUpdatable(IUpdateable updatable)
        {
            if (!updatables.Contains(updatable))
            {
                updatables.Add(updatable);
            }
        }

        public void UnregisterUpdatable(IUpdateable updatable)
        {
            if (updatables.Contains(updatable))
            {
                updatables.Remove(updatable);
            }
        }

        void Update()
        {
            foreach (var updatable in updatables)
            {
                updatable.OnUpdate();
            }
        }

        void LateUpdate()
        {
            foreach (var updatable in updatables)
            {
                updatable.OnLateUpdate();
            }
        }

        void FixedUpdate()
        {
            foreach (var updatable in updatables)
            {
                updatable.OnFixedUpdate();
            }
        }
    }
}
