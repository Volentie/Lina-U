using Lina.Player.Input;
using UnityEngine;

namespace Lina.Player.Object
{
	[RequireComponent(typeof(InputProvider))]
	class RotateObject : MonoBehaviour, IRotateObject
	{
		private IInputProvider _inputProvider;

		void Awake()
		{
			_inputProvider = GetComponent<IInputProvider>();
		}
		public void HandleObjectRotation()
		{
			if (_inputProvider.GetRotatePressed())
			{
				print("Rotating");
			}
		}
	}
}