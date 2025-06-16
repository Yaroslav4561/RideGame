using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    private Vector2 startPosition;
    public float DistanceTravelled { get; private set; } = 0f;

    public TextMeshProUGUI distanceText;
    public GameObject player;

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        DistanceTravelled = Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(startPosition.x, 0));

        if (distanceText != null)
        {
            distanceText.text = $"{DistanceTravelled:F1} ì";
        }
    }
}
