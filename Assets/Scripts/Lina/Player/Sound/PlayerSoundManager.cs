using UnityEngine;
using Lina.State.Player;
using Lina.State;

namespace Lina.Player.Sound
{
	[RequireComponent(typeof(PlayerMoveStateController))]
	[RequireComponent(typeof(PlayerAirStateController))]
	[RequireComponent(typeof(JumpLandProvider))]
	[RequireComponent(typeof(FootstepProvider))]
	public class PlayerSoundManager : MonoBehaviour
	{
		IPlayerMoveStateProvider _playerMoveState;
		IPlayerAirStateProvider _playerAirState;
		IJumpLandProvider _jumpLandProvider;
		IFootstepProvider _footstepProvider;

		void Awake()
		{
			_playerMoveState = GetComponent<IPlayerMoveStateProvider>();
			_playerAirState = GetComponent<IPlayerAirStateProvider>();
			_jumpLandProvider = GetComponent<IJumpLandProvider>();
			_footstepProvider = GetComponent<IFootstepProvider>();
		}

		void Update() => HandlePlayerSounds();

		void HandlePlayerSounds()
		{
			if (_playerAirState.IsCurrentState(PlayerAirState.Grounded))
			{
				if (_playerMoveState.IsCurrentState(PlayerMoveState.Walking))
					_footstepProvider.TryPlayWalking();
				else if (_playerMoveState.IsCurrentState(PlayerMoveState.Running))
					_footstepProvider.TryPlayRunning();
				else if (_playerMoveState.IsCurrentState(PlayerMoveState.Idle))
					_footstepProvider.TryStop();
			}
			else
			{
				_footstepProvider.TryStop();
				if (_playerAirState.IsCurrentState(PlayerAirState.Jumping))
					_jumpLandProvider.TryPlayJumping();
				else if (_playerAirState.IsCurrentState(PlayerAirState.Landing))
					_jumpLandProvider.TryPlayLanding();
			}
		}
	}
}