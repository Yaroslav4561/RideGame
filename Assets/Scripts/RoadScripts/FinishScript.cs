using UnityEngine;

public class TriggerMenuOpener : MonoBehaviour
{
    public GameObject gameOverMenu;  // ����, ��� ����� �������
    public Rigidbody2D rb;  // Rigidbody ���������, ��� �������� ���� ���

    void Start()
    {
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(false);  // ��������� ���� ���������
        }
    }

    // �����, ���� ����������� ��� ���� ��������� � ������
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ����������, �� �� ��������
        if (other.CompareTag("Player"))
        {
            OpenMenu();  // ³�������� ����
            FreezePlayer();  // ���������� ���������
        }
    }

    // ����� ��� �������� ����
    private void OpenMenu()
    {
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(true);  // ³�������� ����
        }
    }

    // ����� ��� ����������� ���������
    private void FreezePlayer()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.zero;  // ��������� ��� ���������
            rb.isKinematic = true;  // �������� ������ ��� ��������� (�� ���� �������� ���� ������ ��� ���� ������ �����䳿)
        }
    }

    // ���� ������� ������� ����, ����� ������ ����� �����
    public void CloseMenu()
    {
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(false);  // ��������� ����
        }
    }
}
