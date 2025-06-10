using UnityEngine;
using Lina.Player.Input;
using Lina.Player.Mouse;
using Lina.State.Player.Mouse;

namespace Lina.Player.Camera
{
	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(MouseSetting))]
	[RequireComponent(typeof(MouseModeManager))]
	public class CameraLook : MonoBehaviour, ICameraLook
	{
		[SerializeField] private float _mouseSensitivity = 10f;

		private IMouseModeProvider _mouseModeProvider;
		private UnityEngine.Camera _cam;

		private float _yaw, _pitch;
		private IInputProvider _inputProvider;
		private IMouseSetting _mouseSetting;

		void Awake()
		{
			_cam = UnityEngine.Camera.main;
			_inputProvider 			= GetComponent<IInputProvider>();
			_mouseSetting 			= GetComponent<IMouseSetting>();
			_mouseModeProvider 		= GetComponent<IMouseModeProvider>();
		}

		void Start()
		{
			_mouseSetting.HideMouseCursor();
			_mouseSetting.LockMouseCenter();
		}

		void LateUpdate()
		{
			Vector2 delta = _inputProvider.GetMouseDelta();
			if (_mouseModeProvider.CurrentMode == MouseMode.FreeLook)
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