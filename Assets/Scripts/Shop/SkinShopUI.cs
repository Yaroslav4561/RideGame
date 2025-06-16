using UnityEngine;

public class SkinShopUI : MonoBehaviour
{
    public Transform container;
    public SkinItemUI skinItemPrefab;
    public SkinData[] allSkins;

    void Start()
    {
        UpdateAll();
    }

    public void UpdateAll()
    {
        foreach (Transform child in container)
            Destroy(child.gameObject);

        foreach (var skin in allSkins)
        {
            var item = Instantiate(skinItemPrefab, container);
            item.Setup(skin); // було item.Init(skin)
        }
    }
}
