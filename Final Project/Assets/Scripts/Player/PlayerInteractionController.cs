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
        [SerializeField] private NetworkInputReceiver inputSystem;
        [SerializeField] private LayerMask interactableLayerMask;
        [SerializeField] private string interactableTag;
        
        private List<IInteractable> interactables = new List<IInteractable>();

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

                var interactable = other.GetComponent<IInteractable>();
                interactables.Add(interactable);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(interactableTag))
            {
                var interactable = other.GetComponent<IInteractable>();
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