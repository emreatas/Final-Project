using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interacbles;
using MyNamespace;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Item> dropableItem = new List<Item>();
    
    public void Interact()
    {
        for (int i = 0; i < dropableItem.Count; i++)
        {
            InteractableUI.Instance.AddToItemPanel(dropableItem[i]);
        }
        
        InteractableUI.Instance.EnableInteractPanel();
    }
}
