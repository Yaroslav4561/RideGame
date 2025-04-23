using UnityEngine;

public class SquareTrigger : MonoBehaviour
{
    public PlatformLift platformLift; // ��������� �� ���������

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wheel"))
        {
            platformLift.UnfreezePlatform(); // ����������� ���������
            platformLift.StartLifting(); // ϳ������ ���������
        }
    }
}
