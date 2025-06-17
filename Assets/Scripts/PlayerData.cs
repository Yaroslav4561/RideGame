using UnityEngine;

public static class PlayerData
{
    private const string BoughtKey = "skinBought_";
    private const string ActiveSkinKey = "ActiveSkin";

    public static bool IsSkinBought(string id)
    {
        return PlayerPrefs.GetInt(BoughtKey + id, 0) == 1;
    }

    public static void BuySkin(string id)
    {
        PlayerPrefs.SetInt(BoughtKey + id, 1);
        PlayerPrefs.Save();
    }

    public static void SetActiveSkin(string id)
    {
        if (!IsSkinBought(id))
        {
            Debug.LogWarning("Скін не куплений: " + id);
            return;
        }

        PlayerPrefs.SetString(ActiveSkinKey, id);
        PlayerPrefs.Save();
    }

    public static string GetActiveSkin()
    {
        string id = PlayerPrefs.GetString(ActiveSkinKey, "");

        if (string.IsNullOrEmpty(id))
        {
            id = "SkinBlue";
            PlayerPrefs.SetString(ActiveSkinKey, id);
            PlayerPrefs.SetInt(BoughtKey + id, 1);
            PlayerPrefs.Save();
        }

        return id;
    }
}
