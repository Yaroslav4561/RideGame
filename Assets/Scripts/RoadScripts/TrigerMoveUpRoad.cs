using UnityEngine;

public class TriggerPlatformActivator : MonoBehaviour
{
    public MovingPlatform2D platformScript; // Посилання на платформу

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            platformScript.ActivatePlatform(); // Запускаємо рух платформи
        }
    }
}
