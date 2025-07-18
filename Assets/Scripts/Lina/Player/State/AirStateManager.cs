using UnityEngine;
using Lina.State.Player;
using Lina.State;
using Lina.Player.Movement;
using Lina.Player.Input;

namespace Lina.Player.State
{
	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(PlayerAirStateManager))]
	public class AirStateManager : MonoBehaviour
	{
		private IInputProvider _inputProvider;
		private IPlayerAirStateProvider _playerAirState;
		private CharacterController _characterController;

		void Awake()
		{
			_playerAirState = GetComponent<IPlayerAirStateProvider>();
			_inputProvider = GetComponent<IInputProvider>();
			_characterController = GetComponent<CharacterController>();
		}

		void Update() => HandleAirState();

		void HandleAirState()
		{
			if (_inputProvider.GetJumpPressed())
				_playerAirState.SetState(PlayerAirState.Jumping);
			else if (_playerAirState.IsCurrentState(PlayerAirState.Landing))
				_playerAirState.SetState(PlayerAirState.Grounded);
			else if (_characterController.isGrounded && !_playerAirState.IsCurrentState(PlayerAirState.Grounded))
				_playerAirState.SetState(PlayerAirState.Landing);
			else if (_playerAirState.IsCurrentState(PlayerAirState.Jumping))
				_playerAirState.SetState(PlayerAirState.OnAir);
		}
	}
}