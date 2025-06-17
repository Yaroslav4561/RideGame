using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinItemUI : MonoBehaviour
{
    public Image skinImage;
    public TextMeshProUGUI priceText;
    public Button selectButton;
    public SkinData skinData;
    public GameObject priceContainer;
    public TextMeshProUGUI buttonText;

    public void Setup(SkinData data)
    {
        skinData = data;
        skinImage.sprite = data.image;
        priceText.text = data.price.ToString();

        selectButton.onClick.RemoveAllListeners();
        selectButton.onClick.AddListener(() =>
        {
            bool alreadyBought = PlayerData.IsSkinBought(data.id);
            int coins = CoinManager.Instance.coinCount;

            // Купівля, якщо ще не куплено і вистачає монет
            if (!alreadyBought && coins >= data.price)
            {
                CoinManager.Instance.Spend(data.price);
                PlayerData.BuySkin(data.id);
                alreadyBought = true;
            }

            // Активувати лише куплений
            if (alreadyBought)
            {
                PlayerData.SetActiveSkin(data.id);

                var switcher = FindObjectOfType<SkinSwitcher>();
                if (switcher != null)
                    switcher.ActivateSkin(data.id);

                var loader = FindObjectOfType<PlayerSkinLoader>();
                if (loader != null)
                    loader.LoadSkin();

                Debug.Log("✅ Скін вибрано: " + data.id);
            }
            else
            {
                Debug.LogWarning("Недостатньо монет або скін не куплено!");
            }

            PlayerPrefs.Save();

            FindObjectOfType<SkinShopUI>()?.UpdateAll();
        });

        UpdateVisualState();
    }

    private void UpdateVisualState()
    {
        bool isBought = PlayerData.IsSkinBought(skinData.id);
        string selectedId = PlayerData.GetActiveSkin();

        priceContainer.SetActive(!isBought);
        buttonText.text = isBought
            ? (skinData.id == selectedId ? "Обрано" : "Обрати")
            : "Купити";
    }
}
