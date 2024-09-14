using AutoShGame.Base.FSMState;

public class PlayerFSMDecision : FSMDecision
{
    private PlayerFSMComponent component;

    public override bool Decide(string state)
    {
        if (component == null) component = GetComponent<PlayerFSMComponent>();

        if (component.manager.CurrentState.GetState() == PlayerState.DEAD) return false;

        return true;
    }
}
