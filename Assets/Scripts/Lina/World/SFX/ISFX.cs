using UnityEngine;

namespace Lina.World.SFX
{
	public interface ISFX
	{
		void PlayOneShot(AudioClip clip);
		void PlayLooping(AudioClip clip);
		void StopPlaying();
	}
}