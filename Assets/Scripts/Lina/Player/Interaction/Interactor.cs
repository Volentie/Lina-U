using Lina.Player.Input;
using Lina.Player.Object;
using Lina.World;
using UnityEngine;

namespace Lina.Player.Interaction
{
    /// <summary>
    /// Handles player interaction with interactable objects in the world.
    /// </summary>
    [RequireComponent(typeof(InputProvider))]
    [RequireComponent(typeof(Raycast))]
    public class Interactor : MonoBehaviour
    {
        private IInputProvider _inputProvider;
        private IRaycast _raycast;

        void Awake()
        {
            _inputProvider = GetComponent<IInputProvider>();
            _raycast = GetComponent<IRaycast>();
        }

        void Update()
        {
            if (_inputProvider.GetInteractPressed())
            {
                TryInteract();
            }
        }

        private void TryInteract()
        {
            RaycastHit hit = _raycast.RayCast();

            if (hit.collider != null)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                interactable?.Interact();
            }
        }
    }
}