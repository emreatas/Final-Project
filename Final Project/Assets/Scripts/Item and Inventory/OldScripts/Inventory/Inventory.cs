using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;
using Utils;
using InventorySystem;
public class Inventory : AbstractSingelton<Inventory>
{

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {

        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

    }
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

    }
}
