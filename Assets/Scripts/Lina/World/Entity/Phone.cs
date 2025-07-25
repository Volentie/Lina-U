using UnityEngine;
using Lina.World.Sound;

namespace Lina.World.Entity
{
	[RequireComponent(typeof(SFX))]
	public class Phone : MonoBehaviour
	{
		private ISFX _sfx;

		void Awake()
		{
			string providerKey = GetType().Name;
			_sfx = GetComponent<ISFX>();
			_sfx.CreateAudioSource(providerKey);
			_sfx.UseAudioSource(providerKey);
		}

		public void PlayLoopingSimple(AudioClip clip)
		{
			_sfx.PlayLooping(clip, 1f);
		}
		
		public void PlayOneShotSimple(AudioClip clip)
		{
			_sfx.PlayOneShot(clip, 1f);
		}
	}
}