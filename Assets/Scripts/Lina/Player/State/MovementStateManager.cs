using UnityEngine;
using Lina.State.Player;
using Lina.Player.Input;
namespace Lina.Player.State
{
	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(PlayerMoveStateManager))]
	public class MovementStateManager : MonoBehaviour
	{
		private IInputProvider _inputProvider;
		private IPlayerMoveStateProvider _playerMoveState;
		void Awake()
		{
			_inputProvider = GetComponent<IInputProvider>();
			_playerMoveState = GetComponent<IPlayerMoveStateProvider>();
		}

		void Update() => HandleMovementStates();

		private bool IsTryingMove()
		{
			return _inputProvider.GetMovementDelta() != Vector2.zero;
		}
		public void HandleMovementStates()
		{
			if (IsTryingMove() && _inputProvider.GetSprintPressed())
				_playerMoveState.SetState(PlayerMoveState.Running);
			else if (IsTryingMove())
				_playerMoveState.SetState(PlayerMoveState.Walking);
			else
				_playerMoveState.SetState(PlayerMoveState.Idle);
		}
	}
}