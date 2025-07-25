using UnityEngine;
using System;

namespace Lina.Player.Object
{
	class Raycast : MonoBehaviour, IRaycast
	{
		public float RayLength => 3f;
		private UnityEngine.Camera _cam;

		void Awake()
		{
			_cam = UnityEngine.Camera.main;
			if (_cam == null)
				throw new Exception("Main camera was not found on Player");
		}

		public RaycastHit RayCast()
		{
			LayerMask layerMask = LayerMask.GetMask("Object", "Interactable", "Weapon");
			Ray ray = _cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
			UnityEngine.Physics.Raycast(ray, out RaycastHit hit, RayLength, layerMask);
			return hit;
		}	
	}
}