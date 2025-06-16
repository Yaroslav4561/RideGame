using UnityEngine;
using System.Collections.Generic;

public static class PlayerData
{
    private const string BoughtKey = "BoughtSkin_";
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
        return PlayerPrefs.GetString(ActiveSkinKey, "");
    }
}
