using UnityEngine;

public class TriggerMenuOpener : MonoBehaviour
{
    public GameObject gameOverMenu;  // Меню, яке треба відкрити
    public Rigidbody2D rb;  // Rigidbody персонажа, щоб зупинити його рух

    void Start()
    {
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(false);  // Початково меню приховано
        }
    }

    // Метод, який викликається при вході персонажа в тригер
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Перевіряємо, чи це персонаж
        if (other.CompareTag("Player"))
        {
            OpenMenu();  // Відкриваємо меню
            FreezePlayer();  // Заморожуємо персонажа
        }
    }

    // Метод для відкриття меню
    private void OpenMenu()
    {
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(true);  // Відкриваємо меню
        }
    }

    // Метод для замороження персонажа
    private void FreezePlayer()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.zero;  // Зупиняємо рух персонажа
            rb.isKinematic = true;  // Вимикаємо фізику для персонажа (не буде впливати сила тяжіння або інші фізичні взаємодії)
        }
    }

    // Якщо потрібно закрити меню, можна додати такий метод
    public void CloseMenu()
    {
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(false);  // Закриваємо меню
        }
    }
}
