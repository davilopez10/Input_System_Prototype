using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyStick : MonoBehaviour
{
  [SerializeField]
  private AnimationCurve[] animations;

  [SerializeField]
  private float speedMin = 0.1f;

  [SerializeField]
  private float speedMax = 1f;

  private AnimationCurve currenAnimationCurve;

  private Vector2 moveVector;

  private Vector2 posInit;

  private Rigidbody2D rigid;

  private float speed;

  private float count = 0;

  public void StopMove()
  {
    if (currenAnimationCurve != null)
    {
      transform.localPosition = posInit;
      currenAnimationCurve = null;
    }
  }

  public void RandomCurve()
  {
    transform.localPosition = posInit;
    currenAnimationCurve = animations[Random.Range(0, animations.Length)];
    speed = Random.Range(speedMin, speedMax);
  }

  private void Awake()
  {
    rigid = GetComponent<Rigidbody2D>();

    posInit = transform.localPosition;
  }

  private void Update()
  {
    if (currenAnimationCurve != null)
    {
      count += Time.deltaTime * speed;
      moveVector.y = currenAnimationCurve.Evaluate(count);
      rigid.MovePosition(posInit + moveVector);

      if (count > 1f)
        count = 0;
    }
  }

}
