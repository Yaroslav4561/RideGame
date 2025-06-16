using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinItemUI : MonoBehaviour
{
    public Image skinImage;
    public TextMeshProUGUI priceText;
    public Button selectButton;
    public SkinData skinData;

    public void Setup(SkinData data)
    {
        skinData = data;
        skinImage.sprite = data.image;

        bool isBought = PlayerPrefs.GetInt("Skin_" + data.id, 0) == 1;
        string selectedSkin = PlayerPrefs.GetString("SelectedSkin", "");

        if (selectedSkin == data.id)
        {
            priceText.text = "Обрано";
            selectButton.interactable = true;
        }
        else if (isBought)
        {
            priceText.text = "Куплено";
            selectButton.interactable = true;
        }
        else
        {
            priceText.text = data.price.ToString() + " 🪙";
            selectButton.interactable = true;
        }

        selectButton.onClick.RemoveAllListeners();
        selectButton.onClick.AddListener(() =>
        {
            if (!isBought)
            {
                int coins = PlayerPrefs.GetInt("Coins", 0);
                if (coins >= data.price)
                {
                    coins -= data.price;
                    PlayerPrefs.SetInt("Coins", coins);
                    PlayerPrefs.SetInt("Skin_" + data.id, 1);
                    Debug.Log("Скін куплено: " + data.id);
                }
                else
                {
                    Debug.Log("Недостатньо монет");
                    return;
                }
            }

            PlayerPrefs.SetString("SelectedSkin", data.id);
            PlayerPrefs.Save();

            FindObjectOfType<SkinShopUI>().UpdateAll();
        });
    }
}
