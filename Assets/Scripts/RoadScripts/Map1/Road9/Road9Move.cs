using System.Collections;
using UnityEngine;

public class PlatformLift2 : MonoBehaviour
{
    public Transform leftPoint2;  // Ліва частина платформи 2 (не рухається)
    public float liftHeight2 = 3f; // Висота підйому правого краю для платформи 2
    public float liftSpeed2 = 2f;  // Швидкість підйому для платформи 2
    public float maxAngle2 = 15f;  // Максимальний кут нахилу для платформи 2

    private Quaternion startRotation2;
    private Vector3 startPosition2;
    private bool isLifting2 = false;
    private bool isFrozen2 = true; // Заморожена платформа 2 (не рухається)

    void Start()
    {
        if (leftPoint2 == null)
        {
            Debug.LogError("⚠ Призначте leftPoint2 у інспекторі!");
            return;
        }

        startRotation2 = transform.rotation;
        startPosition2 = transform.position;
    }

    public void StartLifting2()
    {
        if (isFrozen2) return; // Якщо платформа 2 заморожена - не рухаємось

        if (!isLifting2)
        {
            isLifting2 = true;
            StartCoroutine(LiftUp2());
        }
    }

    public void StartLowering2()
    {
        if (isFrozen2) return; // Якщо платформа 2 заморожена - не рухаємось

        if (isLifting2)
        {
            isLifting2 = false;
            StartCoroutine(LiftDown2());
        }
    }

    // Розморозити платформу 2 при першому тригері
    public void UnfreezePlatform2()
    {
        isFrozen2 = false;
    }

    // Перевірка на заморожену платформу
    public bool IsFrozen2()
    {
        return isFrozen2;
    }

    // Метод для заморожування платформи
    private void FreezePlatform2()
    {
        isFrozen2 = true;
    }

    IEnumerator LiftUp2()
    {
        float timeElapsed = 0f;
        float duration = 1f / liftSpeed2;

        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            float angle = Mathf.Lerp(0f, maxAngle2, t);

            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            transform.position = leftPoint2.position + Quaternion.Euler(0f, 0f, angle) * (startPosition2 - leftPoint2.position);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Після підйому заморожуємо платформу
        FreezePlatform2();
    }

    IEnumerator LiftDown2()
    {
        float timeElapsed = 0f;
        float duration = 1f / liftSpeed2;

        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            float angle = Mathf.Lerp(maxAngle2, 0f, t);

            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            transform.position = leftPoint2.position + Quaternion.Euler(0f, 0f, angle) * (startPosition2 - leftPoint2.position);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = startRotation2;
        transform.position = startPosition2;
    }
    public void ResetPlatform2()
    {
        StopAllCoroutines();
        transform.rotation = startRotation2;
        transform.position = startPosition2;
        isFrozen2 = true;
        isLifting2 = false;
    }

}
