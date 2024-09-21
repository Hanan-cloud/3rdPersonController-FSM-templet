using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, InputMaps.IPlayerActions
{
    public static InputHandler Instance;

    private InputMaps inputs;

    public event Action<Vector2> MovementEvent;
    public event Action<Vector2> MovementCancelEvent;


    public bool isRunning;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);


        if (inputs == null)
            inputs = new InputMaps();

        inputs.Player.SetCallbacks(this);
        inputs.Player.Enable();

        isRunning=false;
    }


    public void OnMovement(InputAction.CallbackContext context)
    {
        //print(context.ReadValue<Vector2>());

        switch (context.phase)
        {
            case InputActionPhase.Performed:

                MovementEvent?.Invoke(context.ReadValue<Vector2>());


                break;


            case InputActionPhase.Canceled:

                MovementEvent?.Invoke(Vector2.zero);


                break;

        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:

                isRunning = !isRunning;


                break;

        }

    }




    private void OnDisable()
    {
        inputs.Player.Disable();

    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }
}

