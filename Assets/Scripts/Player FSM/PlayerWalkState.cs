using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerStateHandler StateHandler) : base(StateHandler) { stateName = "walk"; }
    float i;
    public override void EnterState()
    {
        PlayerAnimation.instance.ChangeAnimation(PlayerStates.move);
        Debug.Log(stateName);
        i = 0;

    }

    public override void FixedUpdateState()
    {

    }

    public override void UpdateState()
    {
        if(StateHandler.CurrentSpeed< StateHandler.MaxWalkspeed)
        {
            StateHandler.CurrentSpeed +=Time.deltaTime * StateHandler.Acceleration;
        }

        base.Moving();

        if (i < 1)
            i += Time.deltaTime ;
        PlayerAnimation.instance.SetBlend(i);

        if (StateHandler.IsMoving==false)
        { StateHandler.SwitchState(StateHandler.playerIdleState); }

        if (InputHandler.Instance.isRunning) { StateHandler.SwitchState(StateHandler.playerRunState); }
    }

    public override void ExsitState()
    {

    }
}
