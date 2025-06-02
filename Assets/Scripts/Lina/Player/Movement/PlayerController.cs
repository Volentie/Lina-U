using Lina.Player.Input;
using Lina.Player.Physics;
using UnityEngine;

namespace Lina.Player.Movement
{
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(HandleGravity))]
	[RequireComponent(typeof(HandleJump))]
	[RequireComponent(typeof(HandleAirAcceleration))]
	public class PlayerController : MonoBehaviour, IPlayerController
	{
		[SerializeField] private float _speed = 5.0f;
		public float Speed => _speed;
		private IInputProvider _inputProvider;
		private IHandleGravity _handleGravity;
		private IHandleJump _handleJump;
		private IHandleAirAcceleration _handleAirMovement;
		private Vector3 _velocity;
		private CharacterController _characterController;
		private bool IsGrounded => _characterController.isGrounded;

		void Awake()
		{
			_characterController = GetComponent<CharacterController>();
			_inputProvider = GetComponent<IInputProvider>();
			_handleGravity = GetComponent<IHandleGravity>();
			_handleJump = GetComponent<IHandleJump>();
			_handleAirMovement = GetComponent<IHandleAirAcceleration>();
		}

		void Update()
		{
			HandleMovement();
		}

		public void HandleMovement()
		{
			Vector3 intendedVelocity = transform.forward * _inputProvider.GetMovementDelta().y + transform.right * _inputProvider.GetMovementDelta().x;
			if (!IsGrounded)
			{
				_handleAirMovement.AirAccelerate(ref _velocity, intendedVelocity);
				_handleGravity.ApplyGravity(ref _velocity);
			}
			else
			{
				_velocity = intendedVelocity;
				_velocity = Vector3.ClampMagnitude(_velocity, 1.0f);
				if (_inputProvider.GetSprintPressed())
					_velocity *= 1.5f;
				if (_inputProvider.GetJumpPressed())
					_handleJump.DoJump(ref _velocity);
			}

			Vector3 moveVec = _velocity * Speed * Time.deltaTime;
			_characterController.Move(moveVec);
		}
	}
}