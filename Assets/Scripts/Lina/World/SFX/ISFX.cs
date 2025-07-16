using UnityEngine;

namespace Lina.World.SFX
{
	public interface ISFX
	{
		bool IsPlaying { get; }
		void PlayOneShot(AudioClip clip);
		void PlayLooping(AudioClip clip);
		void StopPlaying();
	}
}