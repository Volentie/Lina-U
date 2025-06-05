using UnityEngine;

namespace Lina.Player.Physics
{
    class HandleAirAcceleration : MonoBehaviour, IHandleAirAcceleration
    {
		public float AirAcceleration => 1.5f;
		public void AirAccelerate(Vector3 wishDir, ref Vector3 velocity, Transform transform)
		{
			Vector3 forwardDir = transform.forward;
			float projSpeed = Vector3.Dot(wishDir.normalized, forwardDir);
			Vector3 sumForward = new Vector3(forwardDir.x * projSpeed, 0, forwardDir.z * projSpeed);
			sumForward *= AirAcceleration;
			velocity += sumForward * Time.deltaTime;
		}
    }
}