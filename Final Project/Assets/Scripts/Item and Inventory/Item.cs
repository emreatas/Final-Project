using System;
using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Inventory/Item")]
public class Item : ScriptableObject
{
    public string ItemName = "New Item";
    public Sprite Icon = null;
    public ItemTier tier;
    public bool isDefaultItem = false;

    public Color GetTierColor()
    {
        switch (tier)
        {
            case ItemTier.NoTier:
                return new Color(0,0,0,1);
            case ItemTier.Standart:
                return Color.green;
            case ItemTier.Rare:
                return Color.blue;
            case ItemTier.Epic:
                return Color.magenta;
            case ItemTier.Legendary:
                return Color.yellow;
            default:
                return new Color(0,0,0,1);
        }
    }
}



public enum ItemTier
{
    NoTier,
    Standart,
    Rare,
    Epic,
    Legendary
}

