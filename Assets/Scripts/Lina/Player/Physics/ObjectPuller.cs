using UnityEngine;
using Lina.Player.Input;
using Lina.State.Player;
using Lina.State.Player.Mouse;

namespace Lina.Player.Physics
{
	[RequireComponent(typeof(InputProvider))]
	[RequireComponent(typeof(MouseModeManager))]
    public class ObjectPuller : MonoBehaviour, IObjectPuller
    {
		private IInputProvider _inputProvider;
		private IMouseModeProvider _mouseModeProvider;
		private float _scrollShift;
		void Awake()
		{
			_inputProvider = GetComponent<IInputProvider>();
			_mouseModeProvider = GetComponent<IMouseModeProvider>();
		}
		void Update()
		{
			if (_inputProvider.GetScrollWheelDelta() != 0)
			{
				_scrollShift += _inputProvider.GetScrollWheelDelta();
				_scrollShift = Mathf.Clamp(_scrollShift, -5f, 5f);
			}
			if (_mouseModeProvider.CurrentState == MouseMode.ObjectHeld && _scrollShift != 0)
			{
				_scrollShift = 0;
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
