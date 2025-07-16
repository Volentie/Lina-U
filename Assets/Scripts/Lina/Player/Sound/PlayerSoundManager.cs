using UnityEngine;
using Lina.World.SFX;
using Lina.State.Player;
namespace Lina.Player.Sound
{
	[RequireComponent(typeof(ISFX))]
	public class PlayerSoundManager : MonoBehaviour
	{
		[SerializeField]
		private AudioClip _audioClip;

		private ISFX _sfx;
		private IPlayerMoveStateProvider _playerMoveState;

		void Awake()
		{
			_sfx = GetComponent<ISFX>();
			_playerMoveState = GetComponent<IPlayerMoveStateProvider>();
		}

		void Update() => HandlePlayerSounds();

		void HandlePlayerSounds()
		{
			if (_playerMoveState.CurrentState == PlayerMoveState.Walking && !_sfx.IsPlaying)
				_sfx.PlayLooping(_audioClip);
			else if (_playerMoveState.CurrentState != PlayerMoveState.Walking && _playerMoveState.CurrentState != PlayerMoveState.Running && _sfx.IsPlaying)
				_sfx.StopPlaying();
		}
	}
}