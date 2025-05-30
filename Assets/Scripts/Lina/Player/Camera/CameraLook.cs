using UnityEngine;
using Lina.Player.Input;
using Lina.Player.Mouse;

namespace Lina.Player.Camera
{
	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(MouseSetting))]
	public class CameraLook : MonoBehaviour, ICameraLook
	{
		[SerializeField] private float _mouseSensitivity = 10f;
		[SerializeField] private Transform _cameraTransform;

		private float _yaw, _pitch;
		private IInputProvider _inputProvider;
		private IMouseSetting _mouseSetting;

		void Awake()
		{
			_inputProvider = GetComponent<IInputProvider>();
			_mouseSetting = GetComponent<IMouseSetting>();
			if (_cameraTransform == null)
				_cameraTransform = transform.GetChild(0);
		}

		void Start()
		{
			_mouseSetting.HideMouseCursor();
			_mouseSetting.LockMouseCenter();
		}

		void Update()
		{
			Vector2 delta = _inputProvider.GetMouseDelta();
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