using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerStateHandler playerStateHandler;
    protected string stateName = "";
    public PlayerBaseState(PlayerStateHandler stateHandler)
    {
        playerStateHandler = stateHandler;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void ExsitState();

    public virtual void Moving()
    {
        //if (playerStateHandler.IsMoving)
        //{
        //   // playerStateHandler.Rb.velocity = new Vector2(playerStateHandler.MoveDirection.x * playerStateHandler.CurrentSpeed, playerStateHandler.Rb.velocity.y);

        //}
    }
    public virtual void InputHandler()
    {
        //if (playerStateHandler.IsMoving)
        //{
        //   // playerStateHandler.SwitchState(playerStateHandler.playerMovingState);
        //}
    }


    public virtual string GetStateName()
    {
        return stateName;
    }
}
