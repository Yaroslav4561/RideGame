using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public void RestartScene()
    {
        FindObjectOfType<UIManager>().RestartGame();
        CoinManager.Instance.ResetAllCoins();
    }
}
