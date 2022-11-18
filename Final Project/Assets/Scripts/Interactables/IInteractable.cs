using Player;
using UnityEngine;


namespace Interactables
{
    public interface IInteractable
    {
        public void Interact(PlayerInteractionController playerInteractionController);
    }
}