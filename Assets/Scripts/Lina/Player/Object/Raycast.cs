using UnityEngine;

namespace Lina.Player.Object
{
	class Raycast : MonoBehaviour, IRaycast
	{
		public float RayLength => 5f;
		UnityEngine.Camera cam;
		void Awake()
		{
			cam = UnityEngine.Camera.main;
		}
		public RaycastHit RayCast()
		{
			Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
			RaycastHit hit;
			if (UnityEngine.Physics.Raycast(ray, out hit, RayLength))
			{
				Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
			}
			return hit;
		}	
	}
}