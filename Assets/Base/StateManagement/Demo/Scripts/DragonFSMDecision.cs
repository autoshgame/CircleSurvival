namespace AutoShGame.Base.FSMState
{
    public class DragonFSMDecision : FSMDecision
    {
        private DragonFSMComponent dragonFSMComponent;

        private void Awake()
        {
            dragonFSMComponent = GetComponent<DragonFSMComponent>();
        }

        public override bool Decide(string state)
        {
            switch (state)
            {
                case DragonEvent.IDLE:
                    return true;
            }

            return true;
        }
    }
}
