using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB; 
    public float speed = 2f; 
    private bool movingToB = true; 

    void Update()
    {
        if (movingToB)
        {
            transform.position = Vector3.Lerp(transform.position, pointB.position, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, pointB.position) < 0.1f)
            {
                movingToB = false; 
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, pointA.position, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, pointA.position) < 0.1f)
            {
                movingToB = true; 
            }
        }
    }
}
