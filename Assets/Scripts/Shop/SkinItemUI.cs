using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinItemUI : MonoBehaviour
{
    public Image skinImage;
    public TextMeshProUGUI priceText;
    public Button selectButton;
    public SkinData skinData;
    public GameObject priceContainer; // Контейнер для ціни і монети
    public TextMeshProUGUI buttonText;

    public void Setup(SkinData data)
    {
        skinData = data;
        skinImage.sprite = data.image;
        priceText.text = data.price.ToString();

        selectButton.onClick.RemoveAllListeners();
        selectButton.onClick.AddListener(() =>
        {
            bool alreadyBought = PlayerPrefs.GetInt("skinBought_" + data.id, 0) == 1;

            if (!alreadyBought && CoinManager.Instance != null && CoinManager.Instance.coinCount >= data.price)
            {
                CoinManager.Instance.Spend(data.price);
                PlayerPrefs.SetInt("skinBought_" + data.id, 1);
            }

            // Зберегти обраний скін
            PlayerData.SetActiveSkin(data.id);

            // Активувати об'єкт скіна на сцені
            var switcher = FindObjectOfType<SkinSwitcher>();
            if (switcher != null)
                switcher.ActivateSkin(data.id);

            // Застосувати спрайт гравця
            var loader = FindObjectOfType<PlayerSkinLoader>();
            if (loader != null)
                loader.LoadSkin();

            PlayerPrefs.Save();

            Debug.Log("✅ Скін вибрано: " + data.id);

            // Оновити інтерфейс магазину
            FindObjectOfType<SkinShopUI>().UpdateAll();
        });

        UpdateVisualState();
    }

    private void UpdateVisualState()
    {
        bool isBought = PlayerData.IsSkinBought(skinData.id);
        string selectedId = PlayerData.GetActiveSkin();

        if (isBought)
        {
            priceContainer.SetActive(false);

            if (skinData.id == selectedId)
                buttonText.text = "Обрано";
            else
                buttonText.text = "Обрати";
        }
        else
        {
            priceContainer.SetActive(true);
            buttonText.text = "Купити";
        }
    }

}
