using UnityEngine;

namespace Lina.Player.Object
{
	class Raycast : MonoBehaviour, IRaycast
	{
		public float RayLength => 2f;
		private UnityEngine.Camera _cam;
		void Awake()
		{
			_cam = UnityEngine.Camera.main;
		}
		public RaycastHit RayCast()
		{
			LayerMask layerMask = LayerMask.GetMask("Object");
			Ray ray = _cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
			RaycastHit hit;
			UnityEngine.Physics.Raycast(ray, out hit, RayLength, layerMask);
			return hit;
		}	
	}
}