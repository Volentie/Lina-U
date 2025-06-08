using UnityEngine;

namespace Lina.Player.Physics
{
    public class DefaultObjectPuller : IObjectPuller
    {
        private readonly float _pullStrength;
        private readonly float _maxLength;

        public DefaultObjectPuller(float pullStrength = 0.1f, float maxLength = 10f)
        {
            _pullStrength = pullStrength;
            _maxLength     = maxLength;
        }

        public Vector3 CalculateVelocity(Rigidbody body, UnityEngine.Camera cam)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Vector3 targetPos = cam.transform.position + ray.direction;
            Vector3 raw = (targetPos - body.position) / (body.mass * _pullStrength);
            return Vector3.ClampMagnitude(raw, _maxLength);
        }
    }
}
