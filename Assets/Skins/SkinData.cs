using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "Skin Data")]
public class SkinData : ScriptableObject
{
    public string id;
    public Sprite image;
    public int price;
}
