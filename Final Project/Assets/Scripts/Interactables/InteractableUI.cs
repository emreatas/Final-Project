using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace MyNamespace
{
    public class InteractableUI : MonoBehaviour
    {
        [SerializeField] private GameObject interactUI;
        
        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }
        
        private void HandleOnStartInteraction()
        {
            
        }

        private void AddListeners()
        {
            PlayerInteractionController.OnStartInteraction.AddListener(HandleOnStartInteraction);
        }

        
        private void RemoveListeners()
        {
            PlayerInteractionController.OnStartInteraction.RemoveListener(HandleOnStartInteraction);
        }
    }
}


