using UnityEngine;
using System;

namespace Lina.Player.Sound
{
	[RequireComponent(typeof(BaseSoundProvider))]
	public class FootstepProvider : BaseSoundProvider, IFootstepProvider
	{
		[SerializeField]
		private AudioClip _footstepSound;
		private const float WALKPITCH = 1f;
		private const float RUNPITCH = 1.4f;

		protected override void OnAwake()
		{
			if (_footstepSound == null)
				throw new Exception("Footstep sound was not set");
		}

		public void TryPlayWalking()
		{
			if (!_sfx.IsPlaying || _sfx.CurrentPitch != WALKPITCH)
			{
				float time = Mathf.Clamp(_sfx.CurrentTime, 0f, _footstepSound.length - 0.01f);
				_sfx.Stop();

				_sfx.PlayAtTime(_footstepSound, WALKPITCH, time, false);
			}
		}
		public void TryPlayRunning()
		{
			if (!_sfx.IsPlaying || _sfx.CurrentPitch != RUNPITCH)
			{
				float time = Mathf.Clamp(_sfx.CurrentTime, 0f, _footstepSound.length - 0.01f);
				_sfx.Stop();

				_sfx.PlayAtTime(_footstepSound, RUNPITCH, time, false);
			}
		}
	}
}