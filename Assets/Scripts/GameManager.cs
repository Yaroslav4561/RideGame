using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerStartPosition;
    [SerializeField] private GameObject[] coinsOnLevel;

    public void RestartGame()
    {
        // ������� Game Over UI
        gameOverUI.SetActive(false);

        // ���������� ������ � �������� �������
        player.transform.position = playerStartPosition.position;
        player.transform.rotation = playerStartPosition.rotation;

        // ���������� �� ������� �� ����
        foreach (GameObject coin in coinsOnLevel)
        {
            if (coin != null)
                coin.SetActive(true);
        }

        // �����������: ������� ��������, ���� ������� �� Rigidbody2D
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
