using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 1; // Кількість шкоди, що наноситься

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.TakeDamage(damageAmount);
            Debug.Log($"Гравець отримав {damageAmount} шкоди! Поточне HP: {player.GetCurrentHealth()}");
        }
    }
}
