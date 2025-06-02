using UnityEngine;

namespace Lina.Player.Physics
{
	public interface IHandleJump
	{
		float JumpHeight { get; }
		void DoJump(ref Vector3 velocity);
	}
}