using Lina.Player.Input;
using UnityEngine;

namespace Lina.Player.Object
{
	[RequireComponent(typeof(Raycast))]
	[RequireComponent(typeof(InputProvider))]
	class DetectObject : MonoBehaviour, IDetectObject
	{
		private IInputProvider _inputProvider;
		private IRaycast _raycast;
		void Awake()
		{
			_inputProvider = GetComponent<IInputProvider>();
			_raycast = GetComponent<IRaycast>();
		}
		public Rigidbody TryDetectObject()
		{
			if (_inputProvider.GetActionPressed())
			{
				RaycastHit hit = _raycast.RayCast();
				return hit.rigidbody;
			}
			return default;
		}
	}
}