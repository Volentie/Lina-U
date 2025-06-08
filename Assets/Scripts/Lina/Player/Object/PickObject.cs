using Lina.Player.Input;
using UnityEngine;

namespace Lina.Player.Object
{
	[RequireComponent(typeof(Raycast))]
	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(DetectObject))]
	class PickObject : MonoBehaviour, IPickObject
	{
		private IInputProvider _inputProvider;
		private IDetectObject _detectObject;
		private Rigidbody _obj;
		UnityEngine.Camera cam;
		void Awake()
		{
			_inputProvider = GetComponent<IInputProvider>();
			_detectObject = GetComponent<IDetectObject>();
			cam = UnityEngine.Camera.main;
		}
		void Update()
		{
			PickObjectUp();
		}
		public void PickObjectUp()
		{
			if (!_obj)
			{
				_obj = _detectObject.TryDetectObject();
			}
			if (_obj)
			{
				Ray playerEyes = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
				if (_obj.useGravity)
				{
					_obj.useGravity = false;
				}
				_obj.linearVelocity = (cam.transform.position + playerEyes.direction - _obj.position) / (_obj.mass * 0.1f);

				if (_inputProvider.GetActionReleased())
				{
					_obj.useGravity = true;
					_obj = null;
				}
			}
		}
	}
}