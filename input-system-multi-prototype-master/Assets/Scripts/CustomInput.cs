using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInput : MonoBehaviour
{
  public InputAction inputAction;

  private void Awake()
  {
    inputAction.started += context => Started(context);
    inputAction.performed += context => Performed(context);
    inputAction.canceled += context => Canceled(context);
  }

  private void OnEnable()
  {
    inputAction?.Enable();
  }

  private void OnDisable()
  {
    inputAction?.Disable();
  }

  public void Started(InputAction.CallbackContext callback)
  {
    Debug.Log($"Started {callback.action.ReadValue<Vector2>()}");
  }

  public void Performed(InputAction.CallbackContext callback)
  {
    Debug.Log($"Permormed {callback.action.ReadValue<Vector2>()}");
  }

  public void Canceled(InputAction.CallbackContext callback)
  {
    Debug.Log($"Canceled {callback.action.ReadValue<Vector2>()}");
  }
}
