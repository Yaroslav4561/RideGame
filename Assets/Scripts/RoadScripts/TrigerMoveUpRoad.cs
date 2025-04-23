using UnityEngine;

public class TriggerPlatformActivator : MonoBehaviour
{
    public MovingPlatform2D platformScript; // ��������� �� ���������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            platformScript.ActivatePlatform(); // ��������� ��� ���������
        }
    }
}
