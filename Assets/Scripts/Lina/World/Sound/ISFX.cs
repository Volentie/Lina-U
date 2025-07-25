using UnityEngine;

namespace Lina.World.Sound
{
	public interface ISFX
	{
		float CurrentPitch { get; }
		float CurrentTime { get; }
		bool IsPlaying { get; }
		// void CreateAudioSource(string key);
		// void UseAudioSource(string key);
		void PlayOneShot(AudioClip clip, float pitch);
		void PlayAtTime(AudioClip clip, float pitch, float time, bool loop);
		void PlayLooping(AudioClip clip, float pitch);
		//void ResetAudio(AudioClip clip);
		void Stop();
	}
}