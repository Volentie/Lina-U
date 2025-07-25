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
			_sfx = GetComponent<ISFX>();
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