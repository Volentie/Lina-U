using Lina.Player.Input;
using Lina.State.Player.Mouse;
using UnityEngine;

namespace Lina.Player.Object
{
	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(HoldObject))]
	[RequireComponent(typeof(MouseModeManager))]
	class RotateObject : MonoBehaviour, IRotateObject
	{
		[SerializeField] private float _objectRotationSpeed = 10.0f;

		private IInputProvider _inputProvider;
		private IMouseModeProvider _mouseModeProvider;
		private IHoldObject _HoldObject;
		private UnityEngine.Camera _cam;

		void Awake()
		{
			_inputProvider = GetComponent<IInputProvider>();
			_mouseModeProvider = GetComponent<IMouseModeProvider>();
			_HoldObject = GetComponent<IHoldObject>();
			_cam = UnityEngine.Camera.main;
		}
		void Update()
		{
			HandleObjectRotation();
			HandleObjectInputs();
		}
		public void HandleObjectRotation()
		{
			if (_mouseModeProvider.CurrentMode == MouseMode.ObjectManipulation)
			{

				Rigidbody obj = _HoldObject.Held;
				Vector2 delta = _inputProvider.GetMouseDelta();

				float yaw = delta.x * _objectRotationSpeed;
				float pitch = delta.y * _objectRotationSpeed;

				// World‐space “left/right” around camera’s up vector
				Vector3 upAxis = _cam.transform.up;
				// World‐space “up/down” around camera’s right vector
				Vector3 rightAxis = _cam.transform.right;

				// Apply yaw first, then pitch:
				obj.MoveRotation(
					Quaternion.AngleAxis(-yaw, upAxis)    // drag right = positive yaw
				  * Quaternion.AngleAxis(pitch, rightAxis) // drag up    = positive pitch
				  * obj.rotation
				);
			}
		}
		public void HandleObjectInputs()
		{
			if (_inputProvider.GetRotatePressed() && _HoldObject.Held)
				_mouseModeProvider.SetMode(MouseMode.ObjectManipulation);
			if (_inputProvider.GetRotateReleased() && _HoldObject.Held)
				_mouseModeProvider.SetMode(MouseMode.FreeLook);
		}
	}
}