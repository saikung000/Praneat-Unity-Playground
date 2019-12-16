using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(InputAction.CallbackContext value)
    {
        Debug.Log("Move" + value.ReadValue<Vector2>());
    }

    public void Attack(InputAction.CallbackContext value)
    {
        Debug.Log("Attack" );
    }

    public void AttackC1(InputAction.CallbackContext value)
    {
        Debug.Log("AttackC1" );
    }
    public void AttackC2(InputAction.CallbackContext value)
    {
        Debug.Log("AttackC2" );
    }
    public void AttackC3(InputAction.CallbackContext value)
    {
        Debug.Log("AttackC3");
    }
}