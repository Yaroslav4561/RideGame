using UnityEngine;

public class SquareTrigger : MonoBehaviour
{
    public PlatformLift platformLift; // Посилання на платформу

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wheel"))
        {
            platformLift.UnfreezePlatform(); // Розморожуємо платформу
            platformLift.StartLifting(); // Піднімаємо платформу
        }
    }
}
