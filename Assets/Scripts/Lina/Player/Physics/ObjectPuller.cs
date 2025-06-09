using UnityEngine;

namespace Lina.Player.Physics
{
    public class ObjectPuller : MonoBehaviour, IObjectPuller
    {
        public Vector3 CalculateVelocity(Rigidbody body, UnityEngine.Camera cam, float pullStrength, float maxLength)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Vector3 targetPos = cam.transform.position + ray.direction;
            Vector3 raw = (targetPos - body.position) / (body.mass * pullStrength);
            return Vector3.ClampMagnitude(raw, maxLength);
        }
    }
}
