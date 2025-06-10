using Lina.Player.Input;
using Lina.State.Player.Mouse;
using UnityEngine;

namespace Lina.Player.Object
{
	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(PickObject))]
	[RequireComponent(typeof(MouseModeManager))]
	class RotateObject : MonoBehaviour, IRotateObject
	{
		[SerializeField] private float _objectRotationSpeed = 10.0f;

		private IInputProvider _inputProvider;
		private IMouseModeProvider _mouseModeProvider;
		private IPickObject _pickObject;

		void Awake()
		{
			_inputProvider = GetComponent<IInputProvider>();
			_mouseModeProvider = GetComponent<IMouseModeProvider>();
			_pickObject = GetComponent<IPickObject>();
		}
		void FixedUpdate() => HandleObjectRotation();
		public void HandleObjectRotation()
		{
			if (_inputProvider.GetRotatePressed() && _pickObject.Held)
			{
				_mouseModeProvider.SetMode(MouseMode.ObjectManipulation);
				// Store the object
				Rigidbody obj = _pickObject.Held;
				// Rotate object accordingly to mouse position
				float x = _inputProvider.GetMouseDelta().x * _objectRotationSpeed;
				float y = _inputProvider.GetMouseDelta().y * _objectRotationSpeed;
				obj.rotation *= Quaternion.Euler(-y, -x, 0);
			}
			if (_inputProvider.GetRotateReleased() && _pickObject.Held)
			{
				_mouseModeProvider.SetMode(MouseMode.FreeLook);
			}
		}
	}
}