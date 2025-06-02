using UnityEngine;

namespace Lina.Player.Physics
{
	class HandleAirAcceleration : MonoBehaviour, IHandleAirAcceleration
	{
		public void AirAccelerate(ref Vector3 velocity, Vector3 intendedVelocity)
		{
			// TODO: Improve this
			Vector2 sdVelocity = new Vector2(velocity.x, velocity.z);
			Vector2 sdIntendedVelocity = new Vector2(intendedVelocity.x, intendedVelocity.z);
			Vector2 lerpVelocity = Vector2.Lerp(sdVelocity, sdIntendedVelocity, 0.55f);
			velocity = new Vector3(lerpVelocity.x, velocity.y, lerpVelocity.y);
		}
	}
}