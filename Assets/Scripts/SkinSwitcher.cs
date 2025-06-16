using UnityEngine;

public class SkinSwitcher : MonoBehaviour
{
    public GameObject[] skinObjects;

    public void ActivateSkin(string skinId)
    {
        foreach (var skin in skinObjects)
            skin.SetActive(false);

        foreach (var skin in skinObjects)
        {
            if (skin.name == skinId)
            {
                skin.SetActive(true);
                Debug.Log("✅ Активовано скін: " + skinId);
                return;
            }
        }

        Debug.LogWarning("⚠️ Скін з ім'ям '" + skinId + "' не знайдено.");
    }
}
