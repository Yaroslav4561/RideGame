using UnityEngine;

public class OscillatingRotation : MonoBehaviour
{
    public float angleRange = 30f; // Максимальне відхилення
    public float speed = 2f; // Швидкість обертання
    public int rotationDirection = 1; // 1 = за годинниковою, -1 = проти

    private float startAngle; // Початковий кут
    private float timer = 0f;

    void Start()
    {
        startAngle = transform.rotation.eulerAngles.z; // Запам'ятовуємо початковий кут
    }

    void Update()
    {
        timer += Time.deltaTime * speed; // Змінюємо таймер

        // Коливальний рух синусоїдою
        float angleOffset = Mathf.Sin(timer) * angleRange;

        // Встановлюємо новий кут
        transform.rotation = Quaternion.Euler(0f, 0f, startAngle + angleOffset * rotationDirection);
    }
}
