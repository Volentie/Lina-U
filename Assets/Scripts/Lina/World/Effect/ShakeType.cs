using UnityEngine;

namespace Lina.World.Effect
{
	public abstract class ShakeType : ScriptableObject
	{
		/// <summary>
		/// Calculates the rotational offset for the shake animation.
		/// </summary>
		/// <param name="speed">The speed of the shake animation.</param>
		/// <param name="magnitude">The intensity of the shake animation.</param>
		/// <returns>A Vector3 representing the euler angle offset for the rotation.</returns>
		public abstract Vector3 GetShakeVector(float speed, float magnitude);
	}
}
