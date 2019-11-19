using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
  [SerializeField]
  private TextMeshProUGUI playerApointsText;

  [SerializeField]
  private TextMeshProUGUI playerBpointsText;

  public void UpdateTexts(int pointsA, int pointsB)
  {
    playerApointsText.text = pointsA.ToString();
    playerBpointsText.text = pointsB.ToString();
  }

}
