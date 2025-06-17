using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public TextMeshProUGUI coinText;
    public int coinCount;

    private Coin[] allCoins;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ��� �� ���������� �� ������� (�����������)
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        coinCount = PlayerPrefs.GetInt("Coins", 0);
        UpdateUI();

        // ��������� �� ������ �� ����
        allCoins = FindObjectsOfType<Coin>();
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

    public void ResetAllCoins()
    {
        foreach (var coin in allCoins)
        {
            coin.ResetCoin(); // ��� ����� �� ���� � ���� Coin
        }
    }
}
