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
	[RequireComponent(typeof(PlayerGeneralStateController))]
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float _speed = 3.0f;
		public float Speed => _speed;
		private IInputProvider _inputProvider;
		private IHandleGravity _handleGravity;
		private IHandleJump _handleJump;
		private IHandleAirAcceleration _handleAirMovement;
		private IPlayerGeneralStateProvider _playerGeneralState;

		private Vector3 _velocity;
		private CharacterController _characterController;
		void Awake()
		{
			_characterController = GetComponent<CharacterController>();
			_inputProvider = GetComponent<IInputProvider>();
			_handleGravity = GetComponent<IHandleGravity>();
			_handleJump = GetComponent<IHandleJump>();
			_handleAirMovement = GetComponent<IHandleAirAcceleration>();
			_playerGeneralState = GetComponent<IPlayerGeneralStateProvider>();
		}

		void Update() => HandleMovement();

		public void HandleMovement()
		{
			if (!_playerGeneralState.IsCurrentState(PlayerGeneralState.Free))
				return;

			Vector3 wishDir = transform.forward * _inputProvider.GetMovementDelta().y + transform.right * _inputProvider.GetMovementDelta().x;
			wishDir = Vector3.ClampMagnitude(wishDir, 1.0f);
			_velocity = new Vector3(wishDir.x, _velocity.y, wishDir.z);

			if (!_characterController.isGrounded)
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
				}
				if (_inputProvider.GetJumpPressed())
				{
					_handleJump.DoJump(ref _velocity);
				}
			}
			Vector3 moveVec = _velocity * Speed * Time.deltaTime;
			_characterController.Move(moveVec);
		}
	}
}