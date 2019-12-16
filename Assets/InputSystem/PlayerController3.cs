using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3 : MonoBehaviour
{
    ///you need to generate a c# class from your input action asset
    public PlayerInput inputAsset { get; private set; }

    void OnEnable()
    {
        inputAsset = new PlayerInput();
        inputAsset.Enable();

        inputAsset.Player.Move.performed += (x) => Move(x);
        inputAsset.Player.Attack1.performed += (x) => AttackC1(x);
        inputAsset.Player.Attack2.performed += (x) => AttackC2(x);
        inputAsset.Player.Attack3.performed += (x) => AttackC3(x);
    }

    void OnDisable()
    {
        ///Unregister unity event to be safe
        inputAsset.Disable();
    }

    public void Move(InputAction.CallbackContext value)
    {
        Debug.Log("Move");
    }

    public void AttackC1(InputAction.CallbackContext value)
    {
        Debug.Log("AttackC1");
    }
    public void AttackC2(InputAction.CallbackContext value)
    {
        Debug.Log("AttackC2");
    }
    public void AttackC3(InputAction.CallbackContext value)
    {
        Debug.Log("AttackC3");
    }
}