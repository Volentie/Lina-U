using Lina.Player.Input;
using Lina.Player.Physics;
using UnityEngine;

namespace Lina.Player.Object
{
	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(DetectObject))]
	[RequireComponent(typeof(ObjectPuller))]
	class PickObject : MonoBehaviour, IPickObject
	{
		[Header("Pull Settings")]
        [SerializeField] private float _pullStrength 	= 0.1f;
        [SerializeField] private float _maxLength		= 10f;

		private IObjectPuller _objectPuller;
		private IInputProvider _inputProvider;
		private IDetectObject _detectObject;
		private UnityEngine.Camera _cam;
		private Rigidbody _held;

		public Rigidbody Held => _held;

		void Awake()
		{
			_inputProvider = GetComponent<IInputProvider>();
			_detectObject = GetComponent<IDetectObject>();
			_objectPuller = GetComponent<IObjectPuller>();
			_cam = UnityEngine.Camera.main;
		}
		void Update() => TryPickOrRelease();
		void FixedUpdate() => ApplyHoldPhysics();

		public void TryPickOrRelease()
		{
			if (_held == null && _detectObject.TryDetectObject() is Rigidbody candidate)
			{
				_held = candidate;
				_held.useGravity = false;
			}
			else if (_held != null && _inputProvider.GetActionReleased())
			{
				_held.useGravity = true;
				_held = null;
			}
		}

		public void ApplyHoldPhysics()
		{
			if (_held == null) return;
			Vector3 vel = _objectPuller.CalculateVelocity(_held, _cam, _pullStrength, _maxLength);
			_held.linearVelocity = vel;
		}
	}
}