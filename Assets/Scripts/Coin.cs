using UnityEngine;

public class Coin : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool initialActive;

    void Start()
    {
        initialPosition = transform.position;
        initialActive = gameObject.activeSelf;
    }

    public void ResetCoin()
    {
        transform.position = initialPosition;
        gameObject.SetActive(initialActive);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.Instance.AddCoin(1);
            gameObject.SetActive(false);
        }
    }
}
