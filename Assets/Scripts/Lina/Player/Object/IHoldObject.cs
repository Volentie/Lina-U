using UnityEngine;

namespace Lina.Player.Object
{
	interface IHoldObject
	{
		Rigidbody Held { get; }
		void TryPickOrRelease();
		void ApplyHoldPhysics();
	}
}