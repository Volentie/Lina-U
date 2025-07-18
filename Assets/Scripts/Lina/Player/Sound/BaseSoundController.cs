using UnityEngine;
using Lina.World.SFX;
using System;

namespace Lina.Player.Sound
{
	[RequireComponent(typeof(ISFX))]
	public abstract class BaseSoundController : MonoBehaviour, IBaseSoundController
	{
		protected ISFX _sfx;

		void Awake()
		{
			_sfx = GetComponent<ISFX>();
			if (_sfx == null)
			{
				throw new Exception("SFX component not found on " + gameObject.name);
			}

			OnAwake();
		}

		protected virtual void OnAwake() { }

		public void TryStop()
		{
			if (_sfx.IsPlaying())
				_sfx.StopPlaying();
		}
	}
}