using UnityEngine;

namespace Lina.Player.Physics
{
	class HandleAirAcceleration : MonoBehaviour, IHandleAirAcceleration
	{
		public float AirAcceleration => 1.5f;
		public void AirAccelerate(Vector3 wishDir, ref Vector3 velocity, Transform transform)
		{
			// Turn wishDir (local input) into a world‐space direction vector
			Vector3 worldWish = (transform.forward * wishDir.z + transform.right * wishDir.x).normalized;

			// How fast we’d like to move along that direction
			float wishSpeed = wishDir.magnitude * AirAcceleration;

			// How fast we’re already moving along that direction
			float currentSpeed = Vector3.Dot(velocity, worldWish);

			// Speed we need to add
			float addSpeed = wishSpeed - currentSpeed;
			if (addSpeed <= 0f)
				return;

			// How much acceleration we can apply this frame
			float accelSpeed = AirAcceleration * Time.deltaTime * wishSpeed;
			if (accelSpeed > addSpeed)
				accelSpeed = addSpeed;

			// Finally, accelerate
			velocity += worldWish * accelSpeed;
		}
	}
}