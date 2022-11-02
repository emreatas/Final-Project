using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Inventory/Item")]
public class Item : ScriptableObject
{
    public string ItemName = "New Item";
    public Sprite Icon = null;
    public ItemTier tier;
    public bool isDefaultItem = false;
}

public enum ItemTier
{
    NoTier,
    Standart,
    Rare,
    Epic,
    Legendary
}