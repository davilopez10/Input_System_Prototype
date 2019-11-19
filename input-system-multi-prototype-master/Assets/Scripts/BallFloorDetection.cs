using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFloorDetection : MonoBehaviour
{
  [SerializeField]
  private int playerPoint;

  private const string ballTag = "Ball";

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.transform.CompareTag(ballTag))
    {
      GameManager.Instance.SetPoint(playerPoint);
    }
  }
}
