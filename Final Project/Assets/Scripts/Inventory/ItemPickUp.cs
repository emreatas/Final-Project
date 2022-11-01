using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interacbles;
public class ItemPickUp : MonoBehaviour, IInteractable
{
    public Item item;
    
    public void Interact()
    {


    }

    void PickUp()
    {
        Debug.Log("Picking up" + item.name);
        Inventory.Instance.Add(item);
    }
}