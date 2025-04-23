using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // ³�� ��������� (�� ������������� � ������� Y)
    public float rotationSpeed = 50f; // �������� ���������

    void Update()
    {
        // �������� ��'��� ������� ������ ��
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
