using UnityEngine;

public class PlayerSkinLoader : MonoBehaviour
{
    public SpriteRenderer playerSpriteRenderer;
    public SkinData[] availableSkins;

    public void LoadSkin()
    {
        string selectedId = PlayerPrefs.GetString("ActiveSkin", ""); // було SelectedSkin

        foreach (var skin in availableSkins)
        {
            if (skin.id == selectedId)
            {
                if (playerSpriteRenderer != null && skin.image != null)
                {
                    playerSpriteRenderer.sprite = skin.image;
                    Debug.Log("✅ Скін застосовано: " + skin.id);
                }
                return;
            }
        }

        Debug.LogWarning("⚠️ Скін з id " + selectedId + " не знайдено");
    }
}
