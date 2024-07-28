using AutoShGame.Base.FSMState;
using UnityEngine;

public class BotFSMDecision : FSMDecision
{
    private BotFSMComponent botFSMComponent;

    public override bool Decide(string state)
    {
        if (botFSMComponent == null) botFSMComponent = GetComponent<BotFSMComponent>();

        if (state == BotEvent.REVIVE) return true;

        if (botFSMComponent.manager.CurrentState.GetState() == BotEvent.DEAD) return false;

        return true;
    }
}
