namespace Lina.Player.Input
{
	using UnityEngine;
	public interface IInputProvider
	{
		Vector2 GetMouseDelta();
		Vector2 GetMovementDelta();
	}
}