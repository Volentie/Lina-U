namespace Lina.Player.Physics
{
	using UnityEngine;
	interface IHandleAirAcceleration
	{
		void AirAccelerate(ref Vector3 velocity, Vector3 intendedVelocity);
	}
}