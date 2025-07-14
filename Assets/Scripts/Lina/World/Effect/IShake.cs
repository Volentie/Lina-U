using UnityEngine;

namespace Lina.World.Effect
{
	public interface IShake
	{
		float ShakeSpeed { get; }
		float ShakeMagnitude { get; }
		void StartShake(string type);
		void StopShake();
	}
}