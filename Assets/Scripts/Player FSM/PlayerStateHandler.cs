using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateHandler : MonoBehaviour, IInteractable
{
    public static PlayerStateHandler instance;


    private Rigidbody rb;

   

    [Space(20)]
    [SerializeField]
    private LayerMask _groundLayer;


    public PlayerIdleState playerIdleState;
    public PlayerWalkState playerWalkState;
    public PlayerRunState playerRunState;
    public PlayerJumpState playerJumpState;
    public PlayerClimbState playerClimbState;
    public PlayerCrouchState playerCrouchState;


    PlayerBaseState _currentState;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (instance == null)
            instance = this;
        else Destroy(this);

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

    private void OnGUI()
    {
        if (showPlayerInfo == false) return;
        gUIStyle.fontSize = 80;
        GUI.Label(new Rect(10, 10, 100, 20), "Player state: " + _currentState.GetStateName(), gUIStyle);

    }




#endif
}
