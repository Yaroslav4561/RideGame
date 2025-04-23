using UnityEngine;

public class TriggerPlatform2D : MonoBehaviour
{
    public FallingPlatform platformScript; // Посилання на платформу

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wheel")) // Якщо заїхала машина
        {
            platformScript.StartFalling(); // Викликаємо падіння платформи
        }
    }
}
