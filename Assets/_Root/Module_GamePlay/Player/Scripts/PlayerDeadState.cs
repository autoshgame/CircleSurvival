using AutoShGame.Base.FSMState;
using AutoShGame.Base.Observer;
using UnityEngine;

public class PlayerDeadState : FSMState
{
    private PlayerFSMDependency dependency;

    public override string GetState()
    {
        return PlayerState.DEAD;
    }

    public override void OnSetupDependency<T>(T args)
    {
        dependency = args as PlayerFSMDependency;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        dependency.component.movement.CanMove = false;
        dependency.component.weapon.SetStatus(false);

        dependency.component.playerRigidbody2D.transform.localScale = Vector3.zero;
        dependency.component.weapon.gameObject.transform.localScale = Vector3.zero;
        //dependency.component.playerRigidbody2D.gameObject.SetActive(false);
        //dependency.component.weapon.gameObject.SetActive(false);

        PlayerDeadStateTopic playerDeadStateTopic = new PlayerDeadStateTopic();
        ObserverAutoSh.NotifyObservers(playerDeadStateTopic);
    }
}

public class PlayerDeadStateTopic
{
    public string name;
}
