using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    public Transform target; // �����, ������� ��� ���������� ��'���
    public float speed = 50f; // �������� ���������
    public Vector3 axis = Vector3.up; // ³�� ���������

    void Update()
    {
        if (target != null)
        {
            // �������� ��'��� ������� ����� (target.position) �� ������ �� (axis)
            transform.RotateAround(target.position, axis, speed * Time.deltaTime);
        }
    }
}
