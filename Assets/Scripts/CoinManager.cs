using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public TextMeshProUGUI coinText;
    public int coinCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        coinCount = PlayerPrefs.GetInt("Coins", 0); // Завантаження збережених монет
        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        PlayerPrefs.SetInt("Coins", coinCount);
        PlayerPrefs.Save();
        UpdateUI();
    }

    public void Spend(int amount)
    {
        coinCount -= amount;
        PlayerPrefs.SetInt("Coins", coinCount);
        PlayerPrefs.Save();
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = coinCount.ToString();
        }
    }
}
