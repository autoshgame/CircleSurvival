using AutoShGame.Base.FSMState;

namespace CircleSurvival.Module.HomeMenu
{
    public class HomeFSMDecision : FSMDecision
    {
        public override bool Decide(string state)
        {
            return true;
        }
    }
}
