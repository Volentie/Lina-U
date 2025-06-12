using Lina.Player.Input;
using Lina.State.Object;
using UnityEngine;

namespace Lina.Player.Object
{
	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(HoldObject))]
	[RequireComponent(typeof(ObjectModeManager))]
	class RotateObject : MonoBehaviour, IRotateObject
	{
		[SerializeField] private float _objectRotationSpeed = 10.0f;

		private IInputProvider _inputProvider;
		private IObjectModeProvider _objectModeProvider;
		private IHoldObject _holdObject;
		private UnityEngine.Camera _cam;

		void Awake()
		{
			_inputProvider = GetComponent<IInputProvider>();
			_objectModeProvider = GetComponent<IObjectModeProvider>();
			_holdObject = GetComponent<IHoldObject>();
			_cam = UnityEngine.Camera.main;
		}
		void Update()
		{
			HandleObjectInputs();
			HandleObjectRotation();
		}
		public void HandleObjectRotation()
		{
			if (_objectModeProvider.CurrentState == ObjectMode.Rotate)
			{
				Rigidbody obj = _holdObject.Held;
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
			if (_inputProvider.GetRotatePressed() && _holdObject.Held)
				_objectModeProvider.SetState(ObjectMode.Rotate);
				
			if (_inputProvider.GetRotateReleased() && _holdObject.Held)
				_objectModeProvider.SetState(ObjectMode.Hold);
		}
	}
}