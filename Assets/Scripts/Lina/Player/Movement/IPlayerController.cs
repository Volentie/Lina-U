using UnityEngine;

namespace Lina.Player.Movement
{
	public interface IPlayerController
	{
		float Speed { get; }
		void HandleMovement(Vector2 movementDelta);
	}
}