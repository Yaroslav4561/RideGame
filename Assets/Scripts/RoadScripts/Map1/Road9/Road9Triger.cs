using UnityEngine;

public class SquareTrigger2 : MonoBehaviour
{
    public PlatformLift2 platformLift2; // ��������� �� ��������� 2

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wheel") && platformLift2.IsFrozen2()) // �������� �� ���������� ���������
        {
            platformLift2.UnfreezePlatform2(); // ����������� ��������� 2
            platformLift2.StartLifting2(); // ϳ������ ��������� 2
        }
    }
}
