using System.Collections.Generic;
using Interactables;
using PInventory;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [SerializeField] private PlayerInventory playerInventory;
        [SerializeField] private PlayerInputSystem inputSystem;
        [SerializeField] private LayerMask interactableLayerMask;
        [SerializeField] private string interactableTag;
        
        private List<Interactable> interactables = new List<Interactable>();

        public PlayerInventory PlayerInventory => playerInventory;
        
        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(interactableTag))
            {
                InteractableUI.Instance.EnableInteractButton();

                var interactable = other.GetComponent<Interactable>();
                interactables.Add(interactable);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(interactableTag))
            {
                var interactable = other.GetComponent<Interactable>();
                interactables.Remove(interactable);
                
                if (interactables.Count == 0)
                {
                    InteractableUI.Instance.DisableInteractPanel();
                    InteractableUI.Instance.DisableInteractButton();
                }
            }
        }
        
        private void HandleOnInteractionStarted()
        {
            for (int i = 0; i < interactables.Count; i++)
            {
                if (interactables[i] != null)
                {
                    interactables[i].Interact(this);
                }
            }
        }
        
        private void AddListeners()
        {
            inputSystem.OnInteractStarted.AddListener(HandleOnInteractionStarted);
        }

        private void RemoveListeners()
        {
            inputSystem.OnInteractStarted.RemoveListener(HandleOnInteractionStarted);
        }
    }
}