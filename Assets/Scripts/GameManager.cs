using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerStartPosition;
    [SerializeField] private GameObject[] coinsOnLevel;
    void Start()
    {
        // Завантажити вибраний скін
        string skinId = PlayerData.GetActiveSkin();

        var switcher = FindObjectOfType<SkinSwitcher>();
        if (switcher != null)
            switcher.ActivateSkin(skinId);

        var loader = FindObjectOfType<PlayerSkinLoader>();
        if (loader != null)
            loader.LoadSkin();
    }

    public void RestartGame()
    {
        // Сховати Game Over UI
        gameOverUI.SetActive(false);

        // Перемістити гравця в стартову позицію
        player.transform.position = playerStartPosition.position;
        player.transform.rotation = playerStartPosition.rotation;

        // Активувати всі монетки на сцені
        foreach (GameObject coin in coinsOnLevel)
        {
            if (coin != null)
                coin.SetActive(true);
        }

        // Опціонально: скинути швидкість, якщо гравець має Rigidbody2D
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
