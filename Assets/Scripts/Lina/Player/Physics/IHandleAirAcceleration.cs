using UnityEngine;

namespace Lina.Player.Physics
{
	public interface IHandleAirAcceleration
	{
		float AirAcceleration { get; }
		void AirAccelerate(Vector3 wishDir, ref Vector3 velocity, Transform transform);
	}
}