using UnityEngine;
namespace Lina.Player.Sound
{
	public class JumpLandController : BaseSoundController, IJumpLandController
	{
		[SerializeField] private AudioClip _jumpSound;
		[SerializeField] private AudioClip _landSound;

		[Header("Pitch")]
		[SerializeField] private float _jumpPitch = 1f;
		[SerializeField] private float _landPitch = 1f;

		public void TryPlayJumping()
		{
			_sfx.PlayOneShot(_jumpSound, _jumpPitch);
		}
		public void TryPlayLanding()
		{
			_sfx.PlayOneShot(_landSound, _landPitch);
		}
	}
}