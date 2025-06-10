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
		[SerializeField] private Transform _cameraTransform;

		private IMouseModeProvider _mouseModeProvider;

		private float _yaw, _pitch;
		private IInputProvider _inputProvider;
		private IMouseSetting _mouseSetting;

		void Awake()
		{
			if (_cameraTransform == null)
				_cameraTransform 	= transform.GetChild(0);
			_inputProvider 			= GetComponent<IInputProvider>();
			_mouseSetting 			= GetComponent<IMouseSetting>();
			_mouseModeProvider 		= GetComponent<IMouseModeProvider>();
		}

		void Start()
		{
			_mouseSetting.HideMouseCursor();
			_mouseSetting.LockMouseCenter();
		}

		void Update()
		{
			Vector2 delta = _inputProvider.GetMouseDelta();
			if (_mouseModeProvider.CurrentMode == MouseMode.FreeLook)
				HandleLook(delta.x, delta.y);
		}

		public void HandleLook(float deltaX, float deltaY)
		{
			_yaw += deltaX * _mouseSensitivity;
			_pitch = Mathf.Clamp(_pitch - deltaY * _mouseSensitivity, -90, 90);
			transform.localRotation = Quaternion.Euler(0, _yaw, 0);
			_cameraTransform.localRotation = Quaternion.Euler(_pitch, 0, 0);
		}
	}
}