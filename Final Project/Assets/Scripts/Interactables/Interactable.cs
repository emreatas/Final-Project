using Player;
using UnityEngine;


namespace Interactables
{
    public abstract class Interactable : MonoBehaviour
    {
        public abstract void Interact(PlayerInteractionController playerInteractionController);
    }
}