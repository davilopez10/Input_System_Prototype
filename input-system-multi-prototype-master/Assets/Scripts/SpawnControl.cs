using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
  public Transform BallSpawn { get => ballSpawn; }

  [SerializeField]
  private Transform[] spawns;

  [SerializeField]
  private Transform ballSpawn;

  private int currentIndex = 0;

  public void SetPlayerPosition(Transform playerTransform)
  {
    if (currentIndex < spawns.Length)
    {
      playerTransform.position = spawns[currentIndex].position;
      currentIndex++;
    }
  }
}
