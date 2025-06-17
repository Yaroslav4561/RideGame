using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject shopUI;
    public GameObject HUD;

    public PlayerSkinLoader skinLoader; // <-- ����� � ���������

    public void ShowMainMenu()
    {
        mainMenuUI.SetActive(true);
        shopUI.SetActive(false);
        HUD.SetActive(false);
    }

    public void ShowShop()
    {
        mainMenuUI.SetActive(false);
        shopUI.SetActive(true);
        HUD.SetActive(false);
    }

    public void ShowHUD()
    {
        mainMenuUI.SetActive(false);
        shopUI.SetActive(false);
        HUD.SetActive(true);

        if (skinLoader != null)
        {
            skinLoader.LoadSkin(); // ����������� ������ ������
        }

        var skinSwitcher = FindObjectOfType<SkinSwitcher>();
        if (skinSwitcher != null)
        {
            skinSwitcher.ActivateSkin(PlayerData.GetActiveSkin()); // ���������� ��'��� ����
        }
    }


}
