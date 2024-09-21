using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateHandler StateHandler) : base(StateHandler) { stateName = "Run"; }

    public override void EnterState()
    {
        PlayerAnimation.instance.ChangeAnimation(PlayerStates.run);

    }

    public override void FixedUpdateState()
    {

    }

    public override void UpdateState()
    {
        if (StateHandler.CurrentSpeed < StateHandler.MaxRunSpeed)
        {
            StateHandler.CurrentSpeed += Time.deltaTime*StateHandler.Acceleration;
        }
        base.Moving();

        if (StateHandler.IsMoving == false)
        { StateHandler.SwitchState(StateHandler.playerIdleState); }

        if (InputHandler.Instance.isRunning ==false) { StateHandler.SwitchState(StateHandler.playerWalkState); }
    }

    public override void ExsitState()
    {
        InputHandler.Instance.isRunning = false;
    }
}
