using Lina.Player.Input;
using Lina.Player.Physics;
using Lina.State.Player;
using UnityEngine;

namespace Lina.Player.Movement
{
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(HandleGravity))]
	[RequireComponent(typeof(HandleJump))]
	[RequireComponent(typeof(HandleAirAcceleration))]
	[RequireComponent(typeof(PlayerGeneralStateManager))]
	[RequireComponent(typeof(PlayerMoveStateManager))]
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float _speed = 3.0f;
		public float Speed => _speed;
		private IInputProvider _inputProvider;
		private IHandleGravity _handleGravity;
		private IHandleJump _handleJump;
		private IHandleAirAcceleration _handleAirMovement;
		private IPlayerGeneralStateProvider _playerGeneralState;
		private IPlayerMoveStateProvider _playerMoveState;

		private Vector3 _velocity;
		private CharacterController _characterController;
		private bool IsGrounded;

		void Awake()
		{
			_characterController = GetComponent<CharacterController>();
			_inputProvider = GetComponent<IInputProvider>();
			_handleGravity = GetComponent<IHandleGravity>();
			_handleJump = GetComponent<IHandleJump>();
			_handleAirMovement = GetComponent<IHandleAirAcceleration>();
			_playerGeneralState = GetComponent<IPlayerGeneralStateProvider>();
			_playerMoveState = GetComponent<IPlayerMoveStateProvider>();
		}

		void Update() => HandleMovement();

		public void HandleMovement()
		{
			if (_playerGeneralState.CurrentState != PlayerGeneralState.Free)
				return;

			Vector3 wishDir = transform.forward * _inputProvider.GetMovementDelta().y + transform.right * _inputProvider.GetMovementDelta().x;
			wishDir = Vector3.ClampMagnitude(wishDir, 1.0f);

			if (wishDir.magnitude > 0 && _playerMoveState.CurrentState != PlayerMoveState.Running)
				_playerMoveState.SetState(PlayerMoveState.Walking);
			else
				_playerMoveState.SetState(PlayerMoveState.Idle);

			_velocity = new Vector3(wishDir.x, _velocity.y, wishDir.z);
			IsGrounded = _characterController.isGrounded;
			if (!IsGrounded)
			{
				_handleAirMovement.AirAccelerate(wishDir, ref _velocity, transform);
				_handleGravity.ApplyGravity(ref _velocity);
			}
			else
			{
				if (_inputProvider.GetSprintPressed())
				{
					_velocity.x *= 1.5f;
					_velocity.z *= 1.5f;
					_playerMoveState.SetState(PlayerMoveState.Running);
				}
				else if (_inputProvider.GetSprintReleased())
				{
					if (_inputProvider.GetMovementDelta() != Vector2.zero)
						_playerMoveState.SetState(PlayerMoveState.Walking);
					else
						_playerMoveState.SetState(PlayerMoveState.Idle);
				}
				if (_inputProvider.GetJumpPressed())
				{
					_handleJump.DoJump(ref _velocity);
					_playerMoveState.SetState(PlayerMoveState.Jumping);
				}
			}
			Vector3 moveVec = _velocity * Speed * Time.deltaTime;
			_characterController.Move(moveVec);
		}
	}
}