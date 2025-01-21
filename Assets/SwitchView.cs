using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchView : MonoBehaviour
{
    public Transform roomPosition;
    public Transform externalViewPosition;
    public InputActionReference toggleKey;

    private bool isInRoom = true;

    private void OnEnable()
    {
        toggleKey.action.Enable();
        toggleKey.action.performed += OnToggleKey;
    }

    private void OnDisable()
    {
        toggleKey.action.performed -= OnToggleKey;
        toggleKey.action.Disable();
    }

    private void OnToggleKey(InputAction.CallbackContext context)
    {
        if (isInRoom)
        {
            transform.position = externalViewPosition.position;
            transform.rotation = externalViewPosition.rotation;
        }
        else
        {
            transform.position = roomPosition.position;
            transform.rotation = roomPosition.rotation;
        }
        isInRoom = !isInRoom;
    }
}
