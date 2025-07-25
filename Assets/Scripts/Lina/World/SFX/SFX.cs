using System.Collections.Generic;
using UnityEngine;

namespace Lina.World.SFX
{
	public class SFX : MonoBehaviour, ISFX
	{
		private Dictionary<string, AudioSource> _audioSources = new Dictionary<string, AudioSource>();
		private AudioSource _audioSource;
		public float CurrentPitch => _audioSource != null ? _audioSource.pitch : 0f;
		public float CurrentTime => _audioSource != null && _audioSource.clip != null ? _audioSource.time : 0f;

		public void CreateAudioSource(string key)
		{
			if (!_audioSources.ContainsKey(key))
				_audioSources[key] = gameObject.AddComponent<AudioSource>();
		}

		public void UseAudioSource(string key)
		{
			if (_audioSource != _audioSources[key])
			{
				if (_audioSources.TryGetValue(key, out AudioSource source))
					_audioSource = source;
				else
					Debug.LogWarning($"AudioSource for key '{key}' not found.");
			}
		}

		public bool IsPlaying() => _audioSource != null && _audioSource.isPlaying;

		public void StopPlaying()
		{
			if (_audioSource != null)
			{
				_audioSource.Stop();
				_audioSource.clip = null;
			}
		}

		public void PlayOneShot(AudioClip clip, float pitch)
		{
			if (clip != null && _audioSource != null)
			{
				_audioSource.clip = clip;
				_audioSource.pitch = pitch;
				_audioSource.PlayOneShot(clip);
			}
		}

		public void PlayAtTime(AudioClip clip, float pitch, float time, bool loop)
		{
			if (clip != null && _audioSource != null)
			{
				_audioSource.clip = clip;
				_audioSource.pitch = pitch;
				_audioSource.time = time;
				_audioSource.loop = loop;
				_audioSource.Play();
			}
		}

		// public void SetAudioTime(float time)
		// {
		// 	if (_audioSource != null)
		// 		_audioSource.time = time;
		// }

		// public void ResetAudio(AudioClip clip)
		// {
		// 	if (clip != null && _audioSource.time != 0f)
		// 	{
		// 		_audioSource.time = 0f;
		// 	}
		// }

		// public void PlayLooping(AudioClip clip, float pitch)
		// {
		// 	if (clip != null && _audioSource != null)
		// 	{
		// 		_audioSource.clip = clip;
		// 		_audioSource.loop = true;
		// 		_audioSource.pitch = pitch;
		// 		_audioSource.Play();
		// 	}
		// }
	}
}