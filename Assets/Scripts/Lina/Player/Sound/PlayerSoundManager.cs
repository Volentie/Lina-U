using UnityEngine;
using Lina.State.Player;
using Lina.State;
namespace Lina.Player.Sound
{
	[RequireComponent(typeof(PlayerMoveStateManager))]
	[RequireComponent(typeof(PlayerAirStateManager))]
	[RequireComponent(typeof(JumpLandController))]
	[RequireComponent(typeof(FootstepController))]
	public class PlayerSoundManager : MonoBehaviour
	{
		IPlayerMoveStateProvider _playerMoveState;
		IPlayerAirStateProvider _playerAirState;
		IJumpLandController _jumpController;
		IFootstepController _footstepController;

		void Awake()
		{
			_playerMoveState = GetComponent<IPlayerMoveStateProvider>();
			_playerAirState = GetComponent<IPlayerAirStateProvider>();
			_jumpController = GetComponent<IJumpLandController>();
			_footstepController = GetComponent<IFootstepController>();
		}

		void Update() => HandlePlayerSounds();

		void HandlePlayerSounds()
		{
			if (_playerAirState.IsCurrentState(PlayerAirState.Grounded))
			{
				if (_playerMoveState.IsCurrentState(PlayerMoveState.Walking))
					_footstepController.TryPlayWalking();
				else if (_playerMoveState.IsCurrentState(PlayerMoveState.Running))
					_footstepController.TryPlayRunning();
				else if (_playerMoveState.IsCurrentState(PlayerMoveState.Idle))
					_footstepController.TryStop();
			}
			else
			{
				if (_playerAirState.IsCurrentState(PlayerAirState.Jumping))
					_jumpController.TryPlayJumping();
				else if (_playerAirState.IsCurrentState(PlayerAirState.Landing))
					_jumpController.TryPlayLanding();
			}
		}
	}
}