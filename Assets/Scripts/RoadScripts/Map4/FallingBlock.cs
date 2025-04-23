using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float delayBeforeFall = 2f; // Час затримки перед падінням
    public float fallSpeed = 5f; // Швидкість падіння
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Платформа спочатку нерухома
    }

    public void StartFalling()
    {
        StartCoroutine(FallAfterDelay());
    }

    IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeFall);
        rb.isKinematic = false; // Вмикаємо фізику для падіння
        rb.velocity = new Vector2(0, -fallSpeed); // Додаємо швидкість вниз
    }
}
