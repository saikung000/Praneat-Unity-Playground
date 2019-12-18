using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerController4 : MonoBehaviour
{

    public InputAction moveAction;
    public InputAction fireAction;

        public void OnEnable()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    public void OnDisable()
    {
        moveAction.Disable();
        fireAction.Disable();
    }
    void Start()
    {
        fireAction.performed +=
            ctx =>
            {
                if (ctx.interaction is SlowTapInteraction)
                {
                    Debug.Log("FireSlow");
                }
                else
                {
                    Debug.Log("Fire");
                }
            };
        fireAction.started +=
            ctx =>
            {
                Debug.Log("FireStart");
            };
        fireAction.canceled +=
            ctx =>
            {
                Debug.Log("FireCancel");
            };
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null)
            return;

        if (keyboard.spaceKey.wasPressedThisFrame)
            Debug.Log("Space");


        var move = moveAction.ReadValue<Vector2>();
        Move(move);
    }

    private void Move(Vector2 move)
    {
        Debug.Log(move);
    }
}