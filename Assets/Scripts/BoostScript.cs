using UnityEngine;

public class TriggerSpeedBoost : MonoBehaviour
{
    public float speedBoost = 20f; // �������� �����
    public float boostDuration = 1.5f; // ��������� ����������� ����
    private void OnTriggerEnter2D(Collider2D other)
    {

        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            Debug.Log(other.name + " ������� ���� ��������! ���� ��������: " + player.GetCurrentSpeed());
        }
    }
}
