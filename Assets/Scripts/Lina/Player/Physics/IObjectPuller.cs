using UnityEngine;

namespace Lina.Player.Physics
{
    public interface IObjectPuller
    {
        Vector3 CalculateVelocity(Rigidbody body, UnityEngine.Camera cam);
    }
}