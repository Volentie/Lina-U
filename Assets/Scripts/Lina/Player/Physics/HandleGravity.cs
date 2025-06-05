using UnityEngine;

namespace Lina.Player.Physics
{
	public class HandleGravity : MonoBehaviour, IHandleGravity
	{
		[SerializeField] private float _privateScale = -9.81f;
		public float GravityScale => _privateScale;
		public void ApplyGravity(ref Vector3 velocity)
		{
			velocity.y += GravityScale * Time.deltaTime;
		}
	}
}