using UnityEngine;
using Lina.Player.Input;
using Lina.Player.Mouse;
using Lina.State.Object;

namespace Lina.Player.Camera
{
	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(MouseSetting))]
	[RequireComponent(typeof(ObjectModeManager))]
	public class CameraLook : MonoBehaviour, ICameraLook
	{
		[SerializeField] private float _mouseSensitivity = 10f;

		private IObjectModeProvider _objectModeProvider;
		private UnityEngine.Camera _cam;

		private float _yaw, _pitch;
		private IInputProvider _inputProvider;
		private IMouseSetting _mouseSetting;

		void Awake()
		{
			_cam = UnityEngine.Camera.main;
			_inputProvider 			= GetComponent<IInputProvider>();
			_mouseSetting 			= GetComponent<IMouseSetting>();
			_objectModeProvider 	= GetComponent<IObjectModeProvider>();
		}

		void Start()
		{
			_mouseSetting.HideMouseCursor();
			_mouseSetting.LockMouseCenter();
		}

		void LateUpdate()
		{
			Vector2 delta = _inputProvider.GetMouseDelta();
			if (_objectModeProvider.CurrentState == ObjectMode.Hold || _objectModeProvider.CurrentState == ObjectMode.Default)
				HandleLook(delta.x, delta.y);
		}

		public void HandleLook(float deltaX, float deltaY)
		{
			float dx = deltaX * _mouseSensitivity;
			float dy = deltaY * _mouseSensitivity;

			_yaw   += dx;
			_pitch = Mathf.Clamp(_pitch - dy, -90f, 90f);
			transform.localRotation = Quaternion.Euler(0, _yaw, 0);
			_cam.transform.localRotation = Quaternion.Euler(_pitch, 0, 0);
		}
	}
}