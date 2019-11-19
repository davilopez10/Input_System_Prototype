using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
  public Rigidbody2D Rigid2D { get => rigid2D; }

  [SerializeField]
  private Vector2 minMaxForce;

  [SerializeField]
  private float maxVelY = 15f;

  private Rigidbody2D rigid2D;

  private Vector2 velocity;

  public void InitForce(int direction)
  {
    rigid2D.isKinematic = false;
    velocity = Random.Range(minMaxForce.x, minMaxForce.y) * Vector2.right * direction;
    rigid2D.velocity = velocity;
  }

  private void FixedUpdate()
  {
    if (rigid2D.velocity.y > maxVelY)
    {
      velocity = rigid2D.velocity;
      velocity.y = maxVelY;
      rigid2D.velocity = velocity;
    }
  }


  private void Awake()
  {
    rigid2D = GetComponent<Rigidbody2D>();
  }
}
