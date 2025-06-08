namespace Lina.Player.Input
{
	using UnityEngine;
	public class InputProvider : MonoBehaviour, IInputProvider
	{
		public Vector2 GetMouseDelta() => new Vector2(
			Input.GetAxis("Mouse X"),
			Input.GetAxis("Mouse Y")
		);
		public Vector2 GetMovementDelta() => new Vector2(
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		);

		public bool GetJumpPressed() => Input.GetKey(KeyCode.Space);
		public bool GetSprintPressed() => Input.GetKey(KeyCode.LeftShift);
		public bool GetActionPressed() => Input.GetKey(KeyCode.Mouse0);
		public bool GetRotatePressed() => Input.GetKey(KeyCode.R);

		public bool GetJumpReleased() => Input.GetKeyUp(KeyCode.Space);
		public bool GetSprintReleased() => Input.GetKeyUp(KeyCode.LeftShift);
		public bool GetActionReleased() => Input.GetKeyUp(KeyCode.Mouse0);
		public bool GetRotateReleased() => Input.GetKeyUp(KeyCode.R);
	}
}