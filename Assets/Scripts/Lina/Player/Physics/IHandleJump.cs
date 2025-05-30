using UnityEngine;

namespace Lina.Player.Physics
{
	public interface IHandleJump
	{
		float JumpHeight { get; }
		float MovementConstant { get; }
		KeyCode JumpKey { get; }
		void DoJump(ref Vector3 velocity);
	}
}