using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateHandler : MonoBehaviour, IInteractable
{
    public static PlayerStateHandler instance;


    private Rigidbody rb;
    private CharacterController characterController;



    private Vector2 moveDir;
    private bool isMoving=false;

    [Space(20)]
    [SerializeField]
    private LayerMask _groundLayer;

    [SerializeField] float maxWalkspeed;
    [SerializeField] float maxRunSpeed;

    [Range(1,2)]
    [SerializeField] private float acceleration;

    private float _currentSpeed;


    public PlayerIdleState playerIdleState;
    public PlayerWalkState playerWalkState;
    public PlayerRunState playerRunState;
    public PlayerJumpState playerJumpState;
    public PlayerClimbState playerClimbState;
    public PlayerCrouchState playerCrouchState;


    PlayerBaseState _currentState;


    public PlayerStates PlayerAnimation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();

        if (instance == null)
            instance = this;
        else Destroy(this);

    }



    private void OnEnable()
    {
        InputHandler.Instance.MovementEvent += Onmove;  
    }

    private void OnDisable()
    {
        InputHandler.Instance.MovementEvent -= Onmove;
    }

    private void Onmove(Vector2 dir)
    {
        moveDir = dir;
    }

    void Start()
    {
        playerIdleState = new PlayerIdleState(this);
        playerWalkState = new PlayerWalkState(this);
        playerRunState = new PlayerRunState(this);
        playerJumpState = new PlayerJumpState(this);
        playerClimbState = new PlayerClimbState(this);
        playerCrouchState = new PlayerCrouchState(this);
     

        _currentState = playerIdleState;

        _currentState.EnterState();


    }



    private void Update()
    {   

        _currentState.UpdateState();
       // moveDir.Normalized() > 0;

        if(_currentState == playerIdleState && _currentSpeed>0)
        {
            _currentSpeed -= Time.deltaTime*10;
            _currentSpeed = Mathf.Clamp(_currentSpeed, 0, RunSpeed);
        }

    }

    void FixedUpdate()
    {
        _currentState.FixedUpdateState();

    }


    public void SwitchState(PlayerBaseState newState)
    {
        _currentState.ExsitState();
        _currentState = newState;
        _currentState.EnterState();

    }



    public void Interact()
    {
        throw new NotImplementedException();
    }


    [SerializeField] bool showPlayerInfo = false;



#if UNITY_EDITOR

    GUIStyle gUIStyle = new GUIStyle();

    public CharacterController Controller { get => characterController; set => characterController = value; }
    public Vector2 MoveDir { get => moveDir; set => moveDir = value; }
    public bool IsMoving { get => isMoving= MoveDir.magnitude>0; }
    public float Speed { get => MaxWalkspeed;}
    public float RunSpeed { get => MaxRunSpeed;  }
    public float CurrentSpeed { get => _currentSpeed; set => _currentSpeed = value; }
    public float MaxWalkspeed { get => maxWalkspeed; set => maxWalkspeed = value; }
    public float MaxRunSpeed { get => maxRunSpeed; set => maxRunSpeed = value; }
    public float Acceleration { get => acceleration; set => acceleration = value; }

    private void OnGUI()
    {
        if (showPlayerInfo == false) return;
        gUIStyle.fontSize = 40;
        GUI.Label(new Rect(10, 10, 100, 20), "Player state: " + _currentState.GetStateName(), gUIStyle);
        GUI.Label(new Rect(10, 200, 100, 20), "current speed " + CurrentSpeed, gUIStyle);

    }

#endif
}
