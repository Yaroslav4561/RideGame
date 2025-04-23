using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // ��������� �� ���������
    public float offsetY = 5f; // ������ ������ (������� �� �� Y)
    public float offsetZ = -10f; // ³������ �� �� Z (��� �����������)

    void LateUpdate()
    {
        if (player != null)
        {
            // �������� ������ �������� Y � Z ��� ������
            float newY = offsetY;
            float newZ = offsetZ;

            // ������ ������ ����� �� �� X �� ����������
            transform.position = new Vector3(player.position.x, newY, newZ);
        }
    }
}
