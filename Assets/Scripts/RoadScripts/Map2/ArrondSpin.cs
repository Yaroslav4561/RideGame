using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    public Transform target; // Точка, навколо якої обертається об'єкт
    public float speed = 50f; // Швидкість обертання
    public Vector3 axis = Vector3.up; // Вісь обертання

    void Update()
    {
        if (target != null)
        {
            // Обертаємо об'єкт навколо точки (target.position) по заданій осі (axis)
            transform.RotateAround(target.position, axis, speed * Time.deltaTime);
        }
    }
}
