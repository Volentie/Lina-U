using System;
using UnityEngine;
using Assets.Scripts.Utilities;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	[Header("Camera")]
	[SerializeField] private float _mouseSensitivity = 10f;

	[Header("Movement")]
	[SerializeField] private float _walkSpeed = 5f;
	[SerializeField] private float _sprintFactor = 1.5f;
	[SerializeField] private float _jumpHeight = 0.3f;
	[SerializeField] private float _gravity = -9.81f;

	private float _yaw, _pitch;
	private Transform _cameraTransform;
	private CharacterController _controller;
	private Vector3 _velocity;
	private bool IsGrounded => _controller.isGrounded;

	void Awake()
	{
		SetupMouseCursor();
		SetupCamera();
	}

	void SetupMouseCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	void SetupCamera()
	{
		// TODO: Add check
		_cameraTransform = transform.GetChild(0);
		_controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		HandleCameraInput();
		HandleBodyMotion();
	}

	void HandleCameraInput()
	{
		float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
		float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

		_yaw += mouseX;
		_pitch = Mathf.Clamp(_pitch - mouseY, -90f, 90f);

		transform.rotation = Quaternion.Euler(0f, _yaw, 0f);
		_cameraTransform.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
	}

	void HandleBodyMotion()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		bool isSprinting = Input.GetKey(KeyCode.LeftShift);
		bool jumpPressed = Input.GetKey(KeyCode.Space);

		if (IsGrounded && _velocity.y < 0)
			_velocity.y = 0f;

		Vector3 direction = vertical * transform.forward + horizontal * transform.right;
		direction = Vector3.ClampMagnitude(direction, 1);

		_velocity.x = direction.x;
		_velocity.z = direction.z;

		if (IsGrounded)
			HandleJumping(ref _velocity, jumpPressed);
		else
			// TODO: do
			HandleAirAcceleration(ref _velocity, direction);

		HandleSprinting(ref _velocity, isSprinting);

		if (!IsGrounded)
			_velocity.y += _gravity * Time.deltaTime;

		_controller.Move(_velocity * Time.deltaTime * _walkSpeed);
	}
	void HandleJumping(ref Vector3 _velocity, bool jumpPressed)
	{
		if (IsGrounded && jumpPressed)
		{
			_velocity.y = Mathf.Sqrt(-2f * _gravity * _jumpHeight);
		}
	}

	void HandleAirAcceleration(ref Vector3 _velocity, Vector3 direction)
	{
	}

	void HandleSprinting(ref Vector3 _velocity, bool isSprinting)
	{
		if (isSprinting)
		{
			_velocity = _velocity.Modify(x: _velocity.x * _sprintFactor, z: _velocity.z * _sprintFactor);
		}
	}

}