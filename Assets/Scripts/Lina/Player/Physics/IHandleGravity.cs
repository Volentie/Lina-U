using UnityEngine;

namespace Lina.Player.Physics
{
	public interface IHandleGravity
	{
		float GravityScale { get; }
		void ApplyGravity(ref Vector3 velocity);
	}
}