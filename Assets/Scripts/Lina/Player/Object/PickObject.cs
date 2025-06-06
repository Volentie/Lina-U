using Lina.Player.Input;
using UnityEngine;

namespace Lina.Player.Object
{
	[RequireComponent(typeof(Raycast))]
	[RequireComponent(typeof(InputProvider))]
	class PickObject : MonoBehaviour, IPickObject
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
			HandleObjects();
		}
		public void HandleObjects()
		{
			if (_inputProvider.GetActionPressed())
			{
				RaycastHit hit = _raycast.RayCast();
				print(hit.collider);
			}
		}
	}
}