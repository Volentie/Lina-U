using Lina.Player.Input;
using Lina.Player.Physics;
using UnityEngine;

namespace Lina.Player.Movement
{
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(HandleGravity))]
	[RequireComponent(typeof(HandleJump))]
	public class PlayerController : MonoBehaviour, IPlayerController
	{
		[SerializeField] private float _speed = 5.0f;
		public float Speed => _speed;
		private IInputProvider _inputProvider;
		private IHandleGravity _handleGravity;
		private IHandleJump _handleJump;
		private Vector3 _velocity;
		private CharacterController _characterController;
		private bool IsGrounded => _characterController.isGrounded;

		void Awake()
		{
			_characterController = GetComponent<CharacterController>();
			_inputProvider = GetComponent<IInputProvider>();
			_handleGravity = GetComponent<IHandleGravity>();
			_handleJump = GetComponent<IHandleJump>();
		}

		void FixedUpdate()
		{
			HandleMovement(_inputProvider.GetMovementDelta());
		}

		public void HandleMovement(Vector2 movementDelta)
		{
			if (!IsGrounded)
				{
					_handleGravity.ApplyGravity(ref _velocity);
				}
				else
				{
					_velocity = transform.forward * movementDelta.y + transform.right * movementDelta.x;
					_handleJump.DoJump(ref _velocity);
				}
			
			Vector3 moveVec = _velocity * Speed * Time.fixedDeltaTime;
			_characterController.Move(moveVec);
		}
	}
}