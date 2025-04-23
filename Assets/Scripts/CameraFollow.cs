using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Посилання на персонажа
    public float offsetY = 5f; // Висота камери (відстань по осі Y)
    public float offsetZ = -10f; // Відстань по осі Z (для перспективи)

    void LateUpdate()
    {
        if (player != null)
        {
            // Зберігаємо поточні значення Y і Z для камери
            float newY = offsetY;
            float newZ = offsetZ;

            // Рухаємо камеру тільки по осі X за персонажем
            transform.position = new Vector3(player.position.x, newY, newZ);
        }
    }
}
