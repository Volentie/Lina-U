using UnityEngine;

namespace Lina.Player.Physics
{
    public interface IObjectPuller
    {
		void AddScrollShift();
        Vector3 CalculateVelocity(Rigidbody body, UnityEngine.Camera cam, float pullStrength, float maxLength);
    }
}