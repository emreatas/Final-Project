using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interacbles;
public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Item> dropableItem = new List<Item>();

    public void Interact()
    {
        Debug.Log(dropableItem[0].name);
    }
}
