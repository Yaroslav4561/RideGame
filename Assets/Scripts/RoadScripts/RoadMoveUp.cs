using System.Collections;
using UnityEngine;

public class MovingPlatform2D : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� ������
    public float moveHeight = 5f; // ������ ������
    public float delayBeforeMoving = 2f; // �������� ����� �����

    private Vector2 startPosition;
    private bool isActivated = false;

    void Start()
    {
        startPosition = transform.position;
    }

    public void ActivatePlatform()
    {
        if (!isActivated)
        {
            isActivated = true;
            StartCoroutine(DelayedMove());
        }
    }

    IEnumerator DelayedMove()
    {
        yield return new WaitForSeconds(delayBeforeMoving); // ������ ����� ��������
        StartCoroutine(MoveUp());
    }

    IEnumerator MoveUp()
    {
        Vector2 targetPosition = startPosition + new Vector2(0, moveHeight);
        while (transform.position.y < targetPosition.y)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
