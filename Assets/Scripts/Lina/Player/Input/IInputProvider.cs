using UnityEngine;

namespace Lina.Player.Input
{
	public interface IInputProvider
	{
		Vector2 GetMouseDelta();
		Vector2 GetMovementDelta();
		bool GetJumpPressed();
		bool GetSprintPressed();
		bool GetActionPressed();
		bool GetRotatePressed();
		bool GetJumpReleased();
		bool GetSprintReleased();
		bool GetActionReleased();
		bool GetRotateReleased();
	}
}