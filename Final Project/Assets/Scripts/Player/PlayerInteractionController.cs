using System;
using System.Collections;
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

        public static GameEvent OnStartInteraction;
        
        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void HandleOnInteractionStarted()
        {

            Debug.Log("Raycast Hit started");

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10, interactableLayerMask);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                hitColliders[i].GetComponent<IInteractable>().Interact();
            }
        }


        private void AddListeners()
        {
            inputSystem.OnBasicAttackStarted.AddListener(HandleOnInteractionStarted);
        }

        private void RemoveListeners()
        {
            inputSystem.OnBasicAttackStarted.RemoveListener(HandleOnInteractionStarted);
        }


        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigerrr");
            Debug.Log(other.name);
            if (other.gameObject.CompareTag("Interactable"))
            {
                Debug.Log("Tag Correct");
                CanvasManager.instance.OnInteractableStart(true);   
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Interactable"))
            {
                CanvasManager.instance.OnInteractableStart(false);   
            }
        }
    }
}