using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public static PlayerCombat instance;

    public bool canReceiveInput = true;
    public bool inputReceived;

    private void Awake()
    {
        instance = this;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (canReceiveInput)
            {
                inputReceived = true;
                canReceiveInput = false;
                StartCoroutine(ResetCanReceiveInput());
            }
            else
            {
                return;
            }
        }
    }

    private IEnumerator ResetCanReceiveInput()
    {
        yield return new WaitForSeconds(3f);
        canReceiveInput = true;
    }

    public void InputManager()
    {
        if (!canReceiveInput)
        {
            canReceiveInput = true;
        }
        else
        {
            canReceiveInput = false;
        }
    }
}
