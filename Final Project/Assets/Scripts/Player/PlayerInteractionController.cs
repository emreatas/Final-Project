using System.Collections.Generic;
using Interacbles;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [SerializeField] private PlayerInputSystem inputSystem;
        [SerializeField] private LayerMask interactableLayerMask;
        [SerializeField] private float interactRadius;
        [SerializeField] private string interactableTag;


        public static GameEvent OnStartInteraction;

        private List<IInteractable> interactableChest = new List<IInteractable>();

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
                CanvasManager.instance.OnInteractableStart(true);   
                interactableChest.Add(other.GetComponent<IInteractable>());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(interactableTag))
            {
                interactableChest.Remove(other.GetComponent<IInteractable>());
                if (interactableChest.Count == 0)
                {
                    CanvasManager.instance.OnInteractableStart(false);
                }
            }
        }
        
        private void HandleOnInteractionStarted()
        {
            // Debug.Log("Raycast Hit started");
            //
            // Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactRadius, interactableLayerMask);
            //
            // for (int i = 0; i < hitColliders.Length; i++)
            // {
            //     IInteractable interacted = hitColliders[i].GetComponent<IInteractable>();
            //     if (interacted != null)
            //     {
            //         interacted.Interact();
            //     }
            // }
            
            Debug.Log("Interaction started");

            for (int i = 0; i < interactableChest.Count; i++)
            {
                interactableChest[i].Interact();
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