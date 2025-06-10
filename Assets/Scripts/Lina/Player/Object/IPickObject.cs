using UnityEngine;

namespace Lina.Player.Object
{
	interface IPickObject
	{
		Rigidbody Held { get; }
		void TryPickOrRelease();
		void ApplyHoldPhysics();
	}
}