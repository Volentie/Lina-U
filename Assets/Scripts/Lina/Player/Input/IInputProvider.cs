using UnityEngine;

namespace Lina.Player.Input
{
	public interface IInputProvider
	{
		Vector2 GetMouseDelta();
		Vector2 GetMovementDelta();
		float GetScrollWheelDelta();
		bool GetJumpPressed();
		bool GetSprintPressed();
		bool GetActionPressed();
		bool GetRotatePressed();
		bool GetInteractPressed();
		bool GetDropPressed();

		bool GetJumpReleased();
		bool GetSprintReleased();
		bool GetActionReleased();
		bool GetRotateReleased();
	}
}