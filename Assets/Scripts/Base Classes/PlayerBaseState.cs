using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerStateHandler StateHandler;
    protected string stateName = "";

    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Vector3 moveDir;
    public PlayerBaseState(PlayerStateHandler stateHandler)
    {
        StateHandler = stateHandler;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void ExsitState();

    public virtual void Moving()
    {
        if (StateHandler.IsMoving)
        {
            float targetAngle = Mathf.Atan2(StateHandler.MoveDir.x, StateHandler.MoveDir.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(StateHandler.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            StateHandler.transform.rotation = Quaternion.Euler(0f, angle, 0f);
             moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            StateHandler.Controller.Move(moveDir.normalized * StateHandler.CurrentSpeed * Time.deltaTime);
        }
      




    }

    public void Acceleration()
    {
        //_currentSpeed = 
    }

    public virtual string GetStateName()
    {
        return stateName;
    }
}
