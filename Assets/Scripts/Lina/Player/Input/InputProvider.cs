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

		public float GetScrollWheelDelta() => Input.GetAxis("Mouse ScrollWheel");

		public bool GetJumpPressed() => Input.GetKeyDown(KeyCode.Space);
		public bool GetSprintPressed() => Input.GetKey(KeyCode.LeftShift);
		public bool GetActionPressed() => Input.GetKeyDown(KeyCode.Mouse0);
		public bool GetRotatePressed() => Input.GetKey(KeyCode.R);
		public bool GetInteractPressed() => Input.GetKeyDown(KeyCode.E);
		public bool GetDropPressed() => Input.GetKeyDown(KeyCode.G);

		public bool GetJumpReleased() => Input.GetKeyUp(KeyCode.Space);
		public bool GetSprintReleased() => Input.GetKeyUp(KeyCode.LeftShift);
		public bool GetActionReleased() => Input.GetKeyUp(KeyCode.Mouse0);
		public bool GetRotateReleased() => Input.GetKeyUp(KeyCode.R);
	}
}