using UnityEngine;

public class SquareTrigger2 : MonoBehaviour
{
    public PlatformLift2 platformLift2; // Посилання на платформу 2

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wheel") && platformLift2.IsFrozen2()) // Перевірка на заморожену платформу
        {
            platformLift2.UnfreezePlatform2(); // Розморожуємо платформу 2
            platformLift2.StartLifting2(); // Піднімаємо платформу 2
        }
    }
}
