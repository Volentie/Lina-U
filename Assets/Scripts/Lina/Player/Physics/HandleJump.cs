namespace Lina.Player.Physics
{
	using UnityEngine;
	[RequireComponent(typeof(HandleGravity))]
	public class HandleJump : MonoBehaviour, IHandleJump
	{
		public float JumpHeight => 5.0f;
		public float MovementConstant => -2.0f;
		public KeyCode JumpKey => KeyCode.Space;
		private IHandleGravity _gravity;

		void Awake()
		{
			_gravity = GetComponent<IHandleGravity>();
		}

		public void DoJump(ref Vector3 velocity)
		{
			if (Input.GetKey(JumpKey))
			{
				print("keydown");
				velocity.y = Mathf.Sqrt(JumpHeight * MovementConstant * _gravity.GravityScale);
			}
		}
	}
}