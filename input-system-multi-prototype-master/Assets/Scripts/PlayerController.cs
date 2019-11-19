using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  [SerializeField]
  private float speed = 5f;

  [SerializeField]
  private float jumpForce = 5f;

  [SerializeField]
  private float raycastDistance = 0.51f;

  [SerializeField]
  private Vector3 raycastOffset;

  [SerializeField]
  private LayerMask floorLayer;

  private PlayerInput playerInput;

  private Vector2 inputAxis;

  private Rigidbody2D rigid2D;

  private Animator anim;

  private bool isGrounded;

  private int animatorVelocityID = Animator.StringToHash("Velocity");

  private void SetInput(InputAction.CallbackContext callbackContext)
  {
    inputAxis = callbackContext.action.ReadValue<Vector2>();
  }

  private void AddForce(Vector2 direction)
  {
    direction.y = 0;

    rigid2D.AddForce(direction * speed);
  }

  private void Jump(float jumpDirection)
  {
    if (isGrounded)
      rigid2D.velocity = new Vector2(0, jumpDirection * jumpForce);
  }

  private void UpdateAnim()
  {
    anim.SetFloat(animatorVelocityID, Mathf.Abs(inputAxis.x));
  }

  private void Awake()
  {
    rigid2D = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();

    playerInput = GetComponent<PlayerInput>();
    playerInput.actions.FindAction("Move").performed += context => SetInput(context);
    playerInput.actions.FindAction("Jump").performed += context => Jump(context.action.ReadValue<float>());

  }

  private void FixedUpdate()
  {
    AddForce(inputAxis);
  }

  private void Update()
  {
    isGrounded = Physics2D.Raycast(transform.position + raycastOffset, -Vector3.up, raycastDistance, floorLayer).collider != null;
    Debug.DrawLine(transform.position + raycastOffset, (transform.position + raycastOffset) - Vector3.up * raycastDistance, Color.red);

    UpdateAnim();
  }

}