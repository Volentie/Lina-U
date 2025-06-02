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
	}
}