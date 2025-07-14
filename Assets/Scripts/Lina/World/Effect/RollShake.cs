using UnityEngine;

namespace Lina.World.Effect
{
	[CreateAssetMenu(fileName = "NewRollShake", menuName = "Lina/Shake Types/Roll Shake")]
	public class RollShake : ShakeType
	{
		/// <summary>
		/// Provides a shake vector that rotates on the Z-axis (roll).
		/// </summary>
		public override Vector3 GetShakeVector(float speed, float magnitude)
		{
			float shakeValue = Mathf.Sin(Time.time * speed) * magnitude;
			return new Vector3(0, 0, shakeValue);
		}
	}
}
