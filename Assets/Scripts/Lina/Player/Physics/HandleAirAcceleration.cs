namespace Lina.Player.Physics
{
	using UnityEngine;
	/// <summary>
	/// Handles air acceleration physics for mid-air strafing and control.
	/// </summary>
	class HandleAirAcceleration : MonoBehaviour, IHandleAirAcceleration
	{
		[Header("Air Movement Settings")]
		[Tooltip("The maximum speed the player can reach in the air by pressing movement keys.")]
		[SerializeField] private float _maxAirSpeed = 7.5f;

		[Tooltip("How quickly the player can change direction in mid-air.")]
		[SerializeField] private float _acceleration = 10.0f;

		public float AirAcceleration => _acceleration;

		/// <summary>
		/// Accelerates the player in the air based on their input.
		/// </summary>
		/// <param name="wishDir">The desired direction of movement, based on player input. Should be a normalized vector.</param>
		/// <param name="velocity">A reference to the player's current velocity vector.</param>
		/// <param name="transform">The player's transform. This is unused in this implementation but kept for interface compatibility.</param>
		public void AirAccelerate(Vector3 wishDir, ref Vector3 velocity, Transform transform)
		{
			// The 'transform' parameter is unused, but is kept to match the required interface.
			Vector3 horizontalVelocity = new Vector3(velocity.x, 0, velocity.z);
			float wishSpeed = wishDir.magnitude * _maxAirSpeed;

			// Project the current horizontal velocity onto the wish direction.
			float currentSpeed = Vector3.Dot(horizontalVelocity, wishDir);

			// The speed we need to add to reach our desired speed.
			float addSpeed = wishSpeed - currentSpeed;

			if (addSpeed <= 0)
				return;

			// Calculate the acceleration for this frame.
			float accelSpeed = _acceleration * wishSpeed * Time.deltaTime;

			// Cap the acceleration.
			if (accelSpeed > addSpeed)
				accelSpeed = addSpeed;

			// Apply the acceleration to the velocity.
			velocity += wishDir * accelSpeed;
		}
	}
}