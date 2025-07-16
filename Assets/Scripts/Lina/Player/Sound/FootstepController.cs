using UnityEngine;
using Lina.World.SFX;
using Lina.State.Player;
using System;
namespace Lina.Player.Sound
{
	[RequireComponent(typeof(SFX))]
	[RequireComponent(typeof(PlayerMoveStateManager))]
	public class FootstepController : MonoBehaviour, IFootstepController
	{
		[SerializeField]
		private AudioClip _footstepSound;

		private const float WALKPITCH = 1f;
		private const float RUNPITCH = 2f;

		private ISFX _sfx;
		private IPlayerMoveStateProvider _playerMoveState;

		void Awake()
		{
			_sfx = GetComponent<ISFX>();
			_playerMoveState = GetComponent<IPlayerMoveStateProvider>();

			if (_sfx == null || _playerMoveState == null)
				throw new ArgumentException("SFX or PlayerMoveStateManager not found");
			if (_footstepSound == null)
				throw new Exception("Footstep sound was not defined");
		}
		public void TryPlayWalking()
		{
			if (!_sfx.IsPlaying() || _sfx.CurrentPitch != WALKPITCH)
			{
				_sfx.PlayLooping(_footstepSound, WALKPITCH);
			}
		}
		public void TryPlayRunning()
		{
			if (!_sfx.IsPlaying() || _sfx.CurrentPitch != RUNPITCH)
			{
				_sfx.PlayLooping(_footstepSound, RUNPITCH);
			}
		}
		public void TryStop()
		{
			if (_sfx.IsPlaying())
				_sfx.StopPlaying();
		}
	}
}