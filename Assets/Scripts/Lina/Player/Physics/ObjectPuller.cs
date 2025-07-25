using UnityEngine;
using Lina.Player.Input;
using Lina.State.Object;

namespace Lina.Player.Physics
{

	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(ObjectModeManager))]
    public class ObjectPuller : MonoBehaviour, IObjectPuller
    {
		private IInputProvider _inputProvider;
		private IObjectModeProvider _objectModeProvider;
		float maxScrollLength = 0.3f;
		private float _scrollShift;
		void Awake()
		{
			_inputProvider = GetComponent<IInputProvider>();
			_objectModeProvider = GetComponent<IObjectModeProvider>();
		}
		void Update()
		{
			if (_objectModeProvider.CurrentState != ObjectMode.Hold)
			{
				if (_objectModeProvider.CurrentState == ObjectMode.Default && _scrollShift != 0)
					_scrollShift = 0;
				return;
			}
			if (_inputProvider.GetScrollWheelDelta() != 0)
			{
				_scrollShift += _inputProvider.GetScrollWheelDelta();
				_scrollShift = Mathf.Clamp(_scrollShift, -maxScrollLength, maxScrollLength);
			}
		}
		public Vector3 CalculateVelocity(Rigidbody body, UnityEngine.Camera cam, float pullStrength, float maxLength)
		{
			Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			Vector3 targetPos = cam.transform.position + ray.direction;
			targetPos += ray.direction * _scrollShift;
			Vector3 raw = (targetPos - body.position) / (body.mass * pullStrength);
			return Vector3.ClampMagnitude(raw, maxLength);
		}
    }
}
