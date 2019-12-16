using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour, PlayerInput.IPlayerActions
{
    public PlayerInput controls;

    public void OnEnable()
    {
        if (controls == null)
        {
            controls = new PlayerInput();
            // Tell the "gameplay" action map that we want to get told about
            // when actions get triggered.
            controls.Player.SetCallbacks(this);
        }
        controls.Player.Enable();
    }


    public void OnAttack1(InputAction.CallbackContext context)
    {
        Debug.Log("AttackC1");
    }

    public void OnAttack2(InputAction.CallbackContext context)
    {
        Debug.Log("AttackC2");
    }

    public void OnAttack3(InputAction.CallbackContext context)
    {
        Debug.Log("AttackC3");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("Move" + context.ReadValue<Vector2>());
    }
}