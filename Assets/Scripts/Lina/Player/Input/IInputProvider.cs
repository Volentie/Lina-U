using UnityEngine;

namespace Lina.Player.Input
{
	public interface IInputProvider
	{
		Vector2 GetMouseDelta();
		Vector2 GetMovementDelta();
	}
}