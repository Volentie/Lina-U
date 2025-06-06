using UnityEngine;

namespace Lina.Player.Object
{
	interface IRaycast
	{
		float RayLength { get; }
		RaycastHit RayCast();
	}
}