using Lina.Player.Input;
using UnityEngine;

namespace Lina.Player.Object
{
	[RequireComponent(typeof(Raycast))]
	[RequireComponent(typeof(InputProvider))]
	class PickObject : MonoBehaviour, IPickObject
	{
		private IInputProvider _inputProvider;
		private IRaycast _raycast;
		private Rigidbody obj;
		UnityEngine.Camera cam;
		void Awake()
		{
			_inputProvider = GetComponent<IInputProvider>();
			_raycast = GetComponent<IRaycast>();
			cam = UnityEngine.Camera.main;
		}
		void Update()
		{
			HandleObjects();
		}
		public void HandleObjects()
		{
			if (_inputProvider.GetActionPressed())
			{
				RaycastHit hit = _raycast.RayCast();
				if (hit.transform || obj)
				{
					Ray playerEyes = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
					if (!obj)
					{
						obj = hit.rigidbody;
					}
					if (obj != null)
					{
						if (obj.useGravity)
						{
							obj.useGravity = false;
						}
						obj.linearVelocity = (cam.transform.position + playerEyes.direction - obj.position) / obj.mass;
					}
				}
			}
			else if (_inputProvider.GetActionReleased())
			{
				if (obj)
				{
					obj.useGravity = true;
					obj = null;
				}
			}
		}
	}
}