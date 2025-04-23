using UnityEngine;

public class OscillatingRotation : MonoBehaviour
{
    public float angleRange = 30f; // ����������� ���������
    public float speed = 2f; // �������� ���������
    public int rotationDirection = 1; // 1 = �� ������������, -1 = �����

    private float startAngle; // ���������� ���
    private float timer = 0f;

    void Start()
    {
        startAngle = transform.rotation.eulerAngles.z; // �����'������� ���������� ���
    }

    void Update()
    {
        timer += Time.deltaTime * speed; // ������� ������

        // ����������� ��� ���������
        float angleOffset = Mathf.Sin(timer) * angleRange;

        // ������������ ����� ���
        transform.rotation = Quaternion.Euler(0f, 0f, startAngle + angleOffset * rotationDirection);
    }
}
