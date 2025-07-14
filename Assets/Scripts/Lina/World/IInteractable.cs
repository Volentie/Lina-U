using UnityEngine;

namespace Lina.World
{
    /// <summary>
    /// Defines a contract for objects that can be interacted with by the player.
    /// </summary>
    public interface IInteractable
    {
        void Interact();
    }
}