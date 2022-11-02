using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactables;
using Items;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    
    public void Interact()
    {


    }

    public void Reset()
    {
        throw new System.NotImplementedException();
    }

    void PickUp()
    {
        Debug.Log("Picking up" + item.name);
        Inventory.Instance.Add(item);
    }
}