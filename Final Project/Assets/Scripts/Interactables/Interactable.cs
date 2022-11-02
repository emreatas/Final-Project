using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interacbles
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("Interacted with " + name);
            
            
        }
        
    }
}