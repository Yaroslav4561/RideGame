using UnityEngine;
using TMPro; // ϳ�������� TextMeshPro

public class DistanceTracker : MonoBehaviour
{
    private Vector2 startPosition;
    private float distanceTravelled = 0f;

    public TextMeshProUGUI distanceText; // ������������� TextMeshPro
    public GameObject player; // �������
    public GameObject deathPanel; // ������ �����

    void Start()
    {
        startPosition = transform.position; // ������������ �������� �������
        deathPanel.SetActive(false); // ������ ����� �������� �� �����
    }

    void Update()
    {
        if (player == null) // ���� ������� �������
        {
            ShowDeathScreen();
            return;
        }

        // ������ �������� ��������� �� �� X (��� ����� �������� �� Y)
        distanceTravelled = Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(startPosition.x, 0));

        // ��������� UI
        if (distanceText != null)
        {
            distanceText.text = $"{distanceTravelled:F1} �";
        }
    }

    public float GetDistance()
    {
        return distanceTravelled;
    }

    // �������� ������ �����
    void ShowDeathScreen()
    {
        if (distanceText != null)
        {
            distanceText.text = $"{distanceTravelled:F1} �";
        }

        if (deathPanel != null)
        {
            deathPanel.SetActive(true); // �������� ������ �����
        }
    }
}
