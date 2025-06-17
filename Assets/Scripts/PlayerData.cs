using UnityEngine;

public static class PlayerData
{
    private const string BoughtKey = "skinBought_"; // 🟡 було: BoughtSkin_
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
            PlayerPrefs.SetInt(BoughtKey + id, 1); // 🟡 ключ співпадає з UI
            PlayerPrefs.Save();
        }

        return id;
    }
}
