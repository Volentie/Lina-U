using UnityEngine;
using System;

namespace Lina.Player.Sound
{
	public class JumpLandProvider : BaseSoundProvider, IJumpLandProvider
	{
		[SerializeField] private AudioClip _jumpSound;
		[SerializeField] private AudioClip _landSound;

		[Header("Pitch")]
		[SerializeField] private float _jumpPitch = 1f;
		[SerializeField] private float _landPitch = 1f;

		protected override void OnAwake()
		{
			if (_jumpSound == null || _landSound == null)
				throw new Exception("Jump or land sound was not set");
		}

		public void TryPlayJumping() => _sfx.PlayOneShot(_jumpSound, _jumpPitch);
		public void TryPlayLanding() => _sfx.PlayOneShot(_landSound, _landPitch);
	}
}