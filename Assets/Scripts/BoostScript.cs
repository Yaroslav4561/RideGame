using UnityEngine;

public class TriggerSpeedBoost : MonoBehaviour
{
    public float speedBoost = 20f; // Значення бусту
    public float boostDuration = 1.5f; // Тривалість примусового руху
    private void OnTriggerEnter2D(Collider2D other)
    {

        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            Debug.Log(other.name + " отримав буст швидкості! Нова швидкість: " + player.GetCurrentSpeed());
        }
    }
}
