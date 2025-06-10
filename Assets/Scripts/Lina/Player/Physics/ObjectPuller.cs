using UnityEngine;
using Lina.Player.Input;

namespace Lina.Player.Physics
{
	[RequireComponent(typeof(InputProvider))]
    public class ObjectPuller : MonoBehaviour, IObjectPuller
    {
		private IInputProvider _inputProvider;
		private float _scrollShift;
		void Awake()
		{
			_inputProvider = GetComponent<IInputProvider>();
		}
		public void AddScrollShift()
		{
			if (_inputProvider.GetScrollWheelDelta() != 0)
			{
				_scrollShift += _inputProvider.GetScrollWheelDelta();
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
