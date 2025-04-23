using UnityEngine;
using TMPro; // Підключаємо TextMeshPro

public class DistanceTracker : MonoBehaviour
{
    private Vector2 startPosition;
    private float distanceTravelled = 0f;

    public TextMeshProUGUI distanceText; // Використовуємо TextMeshPro
    public GameObject player; // Гравець
    public GameObject deathPanel; // Панель смерті

    void Start()
    {
        startPosition = transform.position; // Запам’ятовуємо стартову позицію
        deathPanel.SetActive(false); // Панель смерті вимкнена на старті
    }

    void Update()
    {
        if (player == null) // Якщо гравець мертвий
        {
            ShowDeathScreen();
            return;
        }

        // Рахуємо пройдену дистанцію по осі X (або можна рахувати по Y)
        distanceTravelled = Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(startPosition.x, 0));

        // Оновлюємо UI
        if (distanceText != null)
        {
            distanceText.text = $"{distanceTravelled:F1} м";
        }
    }

    public float GetDistance()
    {
        return distanceTravelled;
    }

    // Виводимо панель смерті
    void ShowDeathScreen()
    {
        if (distanceText != null)
        {
            distanceText.text = $"{distanceTravelled:F1} м";
        }

        if (deathPanel != null)
        {
            deathPanel.SetActive(true); // Показуємо панель смерті
        }
    }
}
