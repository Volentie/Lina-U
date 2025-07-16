using UnityEngine;
using Lina.State.Player;
namespace Lina.Player.Sound
{
	[RequireComponent(typeof(PlayerMoveStateManager))]
	[RequireComponent(typeof(FootstepController))]
	public class PlayerSoundManager : MonoBehaviour
	{
		IPlayerMoveStateProvider _playerMoveState;
		IFootstepController _footstepController;

		void Awake()
		{
			_playerMoveState = GetComponent<IPlayerMoveStateProvider>();
			_footstepController = GetComponent<IFootstepController>();
		}

		void Update() => HandlePlayerSounds();

		void HandlePlayerSounds()
		{
			if (_playerMoveState.IsCurrentState(PlayerMoveState.Walking))
			{
				_footstepController.TryPlayWalking();
			}
			else if (_playerMoveState.IsCurrentState(PlayerMoveState.Running))
			{
				_footstepController.TryPlayRunning();
			}
			else if (_playerMoveState.IsCurrentState(PlayerMoveState.Idle))
				_footstepController.TryStop();
		}
	}
}