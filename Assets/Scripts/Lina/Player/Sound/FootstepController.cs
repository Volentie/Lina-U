using UnityEngine;
using Lina.State;
using System;
namespace Lina.Player.Sound
{
	[RequireComponent(typeof(BaseSoundController))]
	[RequireComponent(typeof(PlayerAirStateManager))]
	public class FootstepController : BaseSoundController, IFootstepController
	{
		[SerializeField]
		private AudioClip _footstepSound;

		private const float WALKPITCH = 1f;
		private const float RUNPITCH = 2f;

		protected override void OnAwake()
		{
			if (_footstepSound == null)
				throw new Exception("Footstep sound was not defined");
		}
		public void TryPlayWalking()
		{
			if (!_sfx.IsPlaying() || _sfx.CurrentPitch != WALKPITCH)
				_sfx.PlayLooping(_footstepSound, WALKPITCH);
		}
		public void TryPlayRunning()
		{
			if (!_sfx.IsPlaying() || _sfx.CurrentPitch != RUNPITCH)
				_sfx.PlayLooping(_footstepSound, RUNPITCH);
		}
	}
}