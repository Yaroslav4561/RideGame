using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // Вісь обертання (за замовчуванням — навколо Y)
    public float rotationSpeed = 50f; // Швидкість обертання

    void Update()
    {
        // Обертаємо об'єкт навколо власної осі
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
