using UnityEngine;

[System.Serializable]
public abstract class ItemData
{
    public string id;
    public string name;
    public string description;
    public int basePrice;
    public Sprite sprite;
    public AnimatorOverrideController animatorOverrideController;
}
