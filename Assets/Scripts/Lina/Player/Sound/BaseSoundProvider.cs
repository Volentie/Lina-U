using UnityEngine;
using Lina.World.Sound;
using System;

namespace Lina.Player.Sound
{
	[RequireComponent(typeof(ISFX))]
	public abstract class BaseSoundProvider : MonoBehaviour, IBaseSoundProvider
	{
		protected ISFX _sfx;
		protected string _providerKey;
		protected void UseMySource() => _sfx.UseAudioSource(_providerKey);

		void Awake()
		{
			_providerKey = GetType().Name;
			_sfx = GetComponent<ISFX>();
			if (_sfx == null)
				throw new Exception("SFX component not found on " + gameObject.name);

			_sfx.CreateAudioSource(_providerKey);

			OnAwake();
		}

		protected void PlayOneShot(AudioClip clip, float pitch)
		{
			UseMySource();
			_sfx.PlayOneShot(clip, pitch);
		}

		protected void PlayAtTime(AudioClip clip, float pitch, float time, bool loop)
		{
			UseMySource();
			_sfx.PlayAtTime(clip, pitch, time, loop);
		}

		// protected void PlayLooping(AudioClip clip, float pitch)
		// {
		// 	_sfx.UseAudioSource(_providerKey);
		// 	_sfx.PlayLooping(clip, pitch);
		// }

		protected bool IsPlaying()
		{
			UseMySource();
			return _sfx.IsPlaying();
		}

		protected float CurrentPitch()
		{
			UseMySource();
			return _sfx.CurrentPitch;
		}

		// protected void ResetAudio(AudioClip clip)
		// {
		// 	_sfx.UseAudioSource(_providerKey);
		// 	_sfx.ResetAudio(clip);
		// }

		protected virtual void OnAwake() { }

		public void TryStop()
		{
			UseMySource();
			if (_sfx.IsPlaying())
				_sfx.StopPlaying();
		}
	}
}