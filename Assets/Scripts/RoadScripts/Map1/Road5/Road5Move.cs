using System.Collections;
using UnityEngine;

public class PlatformLift : MonoBehaviour
{
    public Transform leftPoint;  // Ліва частина платформи (не рухається)
    public float liftHeight = 3f; // Висота підйому правого краю
    public float liftSpeed = 2f;  // Швидкість підйому
    public float maxAngle = 15f;  // Максимальний кут нахилу

    private Quaternion startRotation;
    private Vector3 startPosition;
    private bool isLifting = false;
    private bool isFrozen = true; // Заморожена платформа (не рухається)

    void Start()
    {
        if (leftPoint == null)
        {
            Debug.LogError("⚠ Призначте leftPoint у інспекторі!");
            return;
        }

        startRotation = transform.rotation;
        startPosition = transform.position;
    }

    public void StartLifting()
    {
        if (isFrozen) return; // Якщо платформа заморожена - не рухаємось

        if (!isLifting)
        {
            isLifting = true;
            StartCoroutine(LiftUp());
        }
    }

    public void StartLowering()
    {
        if (isFrozen) return; // Якщо платформа заморожена - не рухаємось

        if (isLifting)
        {
            isLifting = false;
            StartCoroutine(LiftDown());
        }
    }

    // Розморозити платформу при першому тригері
    public void UnfreezePlatform()
    {
        isFrozen = false;
    }

    IEnumerator LiftUp()
    {
        float timeElapsed = 0f;
        float duration = 1f / liftSpeed;

        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            float angle = Mathf.Lerp(0f, maxAngle, t);

            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            transform.position = leftPoint.position + Quaternion.Euler(0f, 0f, angle) * (startPosition - leftPoint.position);

            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator LiftDown()
    {
        float timeElapsed = 0f;
        float duration = 1f / liftSpeed;

        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            float angle = Mathf.Lerp(maxAngle, 0f, t);

            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            transform.position = leftPoint.position + Quaternion.Euler(0f, 0f, angle) * (startPosition - leftPoint.position);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = startRotation;
        transform.position = startPosition;
    }
    public void ResetPlatform()
    {
        StopAllCoroutines();
        transform.rotation = startRotation;
        transform.position = startPosition;
        isFrozen = true;
        isLifting = false;
    }

}
