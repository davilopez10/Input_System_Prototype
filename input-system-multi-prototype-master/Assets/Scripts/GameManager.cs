using System.Collections;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance;

  [SerializeField]
  private Ball ballPrefab;

  [SerializeField]
  private Color[] playersColor;

  [SerializeField]
  private CrazyStick stick;

  private Ball ballInstance;

  private SpawnControl spawnControl;

  private int currentPlayers;

  private int pointsPlayer1;

  private int pointsPlayer2;

  private CanvasManager canvasManager;

  public void JoinPlayer(PlayerInput playerInput)
  {
    if (currentPlayers % 2 == 0)
      playerInput.transform.localScale = new Vector3(-1, 1, 1);

    playerInput.GetComponent<SpriteRenderer>().color = playersColor[currentPlayers];
    spawnControl.SetPlayerPosition(playerInput.transform);
    currentPlayers++;

    if (currentPlayers == 2)
    {
      ballInstance = Instantiate(ballPrefab, spawnControl.BallSpawn.position, Quaternion.identity);

      ballInstance.Rigid2D.isKinematic = true;
      StartCoroutine(DelayAction(() => ballInstance.InitForce(Random.value > 0.5 ? 1 : -1), 2f));
    }
  }

  public void SetPoint(int player)
  {
    int direction = -1;
    switch (player)
    {
      case 1:
        pointsPlayer1++;
        break;

      case 2:
        pointsPlayer2++;
        direction = 1;
        break;

      default:
        Debug.Log("[GameManager] Player don't exist");
        break;
    }

    canvasManager.UpdateTexts(pointsPlayer1, pointsPlayer2);

    ResetBall(direction);
  }

  public IEnumerator DelayAction(Action callback, float time)
  {
    yield return new WaitForSeconds(time);
    callback?.Invoke();
  }

  private void ResetBall(int direction)
  {
    ballInstance.Rigid2D.velocity = Vector3.zero;
    ballInstance.Rigid2D.angularVelocity = 0;
    ballInstance.Rigid2D.isKinematic = true;
    ballInstance.transform.position = spawnControl.BallSpawn.position;

    StartCoroutine(DelayAction(() => ballInstance.InitForce(direction), 2f));

    stick.StopMove();

    if (Random.value > 0.7f)
      stick.RandomCurve();
  }

  private void Awake()
  {
    Instance = this;

    spawnControl = GetComponent<SpawnControl>();
    canvasManager = GetComponent<CanvasManager>();
  }
}
