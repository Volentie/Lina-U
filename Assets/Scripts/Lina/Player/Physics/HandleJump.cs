namespace Lina.Player.Physics
{
	using UnityEngine;
	[RequireComponent(typeof(HandleGravity))]
	public class HandleJump : MonoBehaviour, IHandleJump
	{
		[SerializeField] private float _jumpHeight = 0.2f;
		public float JumpHeight => _jumpHeight;
		private IHandleGravity _gravity;

		void Awake()
		{
			_gravity = GetComponent<IHandleGravity>();
		}

		public void DoJump(ref Vector3 velocity)
		{
			 // v0 = sqrt(h * -2 * g)
			velocity.y = Mathf.Sqrt(JumpHeight * -2f * _gravity.GravityScale);
		}
	}
}