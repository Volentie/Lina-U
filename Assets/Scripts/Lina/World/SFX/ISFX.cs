using UnityEngine;

namespace Lina.World.SFX
{
	public interface ISFX
	{
		float CurrentPitch { get; }
		bool IsPlaying();
		void PlayOneShot(AudioClip clip, float pitch);
		void PlayLooping(AudioClip clip, float pitch);
		void StopPlaying();
	}
}