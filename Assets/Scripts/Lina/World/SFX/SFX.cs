using UnityEngine;

/// <summary>
/// A reusable component for playing audio clips. Can be controlled by other scripts or UnityEvents.
/// </summary>
namespace Lina.World.SFX
{
	[RequireComponent(typeof(AudioSource))]
	public class SFX : MonoBehaviour, ISFX
	{
		private AudioSource _audioSource;

		public float CurrentPitch => _audioSource.pitch;

		void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		public bool IsPlaying()
		{
			return _audioSource.isPlaying;
		}

		public void StopPlaying()
		{
			_audioSource.Stop();
		}

		public void PlayOneShot(AudioClip clip, float pitch)
		{
			if (clip != null)
			{
				_audioSource.pitch = pitch;
				_audioSource.PlayOneShot(clip);
			}
		}

		public void ResetAudio(AudioClip clip)
		{
			if (clip != null)
			{
				_audioSource.time = 0f;
			}
		}

		public void PlayLooping(AudioClip clip, float pitch)
		{
			if (clip != null)
			{
				_audioSource.clip = clip;
				_audioSource.loop = true;
				_audioSource.pitch = pitch;
				_audioSource.Play();
			}
		}
	}
}