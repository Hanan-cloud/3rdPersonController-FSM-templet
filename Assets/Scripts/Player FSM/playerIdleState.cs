using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{

    public PlayerIdleState(PlayerStateHandler StateHandler) : base(StateHandler) { stateName = "Idle"; }

    public override void EnterState()
    {
        PlayerAnimation.instance.ChangeAnimation(PlayerStates.idle);
        Debug.Log(stateName);
    }


    public override void FixedUpdateState()
    {

    }

    public override void UpdateState()
    {

        base.Moving();
        if(StateHandler.IsMoving) { StateHandler.SwitchState(StateHandler.playerWalkState); }


    }

    public override void ExsitState()
    {

    }
}
