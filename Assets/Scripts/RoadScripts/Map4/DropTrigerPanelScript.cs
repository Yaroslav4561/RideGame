using UnityEngine;

public class TriggerPlatform2D : MonoBehaviour
{
    public FallingPlatform platformScript; // ��������� �� ���������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wheel")) // ���� ������ ������
        {
            platformScript.StartFalling(); // ��������� ������ ���������
        }
    }
}
