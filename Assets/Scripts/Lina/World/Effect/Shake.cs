using UnityEngine;

namespace Lina.World.Effect
{
    public class Shake : MonoBehaviour, IShake
    {
        [Header("Animation")]
        [SerializeField] private float _shakeSpeed = 15;
        [SerializeField] private float _shakeMagnitude = 3f;

        public float ShakeSpeed => _shakeSpeed;
        public float ShakeMagnitude => _shakeMagnitude;

        private bool _isShaking = false;
        private ShakeType _currentShakeType;
        private Vector3 _initialRotation;

        void Awake()
        {
            _initialRotation = transform.localEulerAngles;
        }

        public void StartShake(ShakeType type)
        {
            if (type == null) return;

            _currentShakeType = type;
            _isShaking = true;
        }

        void Update()
        {
            if (!_isShaking) return;

            Vector3 shakeVector = _currentShakeType.GetShakeVector(ShakeSpeed, ShakeMagnitude);
            transform.localEulerAngles = _initialRotation + shakeVector;
        }

        public void StopShake()
        {
            _isShaking = false;
            transform.localEulerAngles = _initialRotation;
        }
    }
}