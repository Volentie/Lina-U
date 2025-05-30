namespace Lina.Player.Physics
{
	using UnityEngine;
	public class HandleGravity : MonoBehaviour, IHandleGravity
	{
		public float GravityScale => -9.81f;
		public void ApplyGravity(ref Vector3 velocity)
		{
			velocity.y += GravityScale * Time.deltaTime;
		}
	}
}