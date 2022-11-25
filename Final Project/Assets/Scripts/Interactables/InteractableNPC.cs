using System;
using System.Collections;
using System.Collections.Generic;
using Interactables;
using Player;
using UnityEngine;

public class InteractableNPC : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject dialgogueGO;
    
    public void Interact(PlayerInteractionController playerInteractionController)
    {
        dialgogueGO.SetActive(true);   
    }
}
