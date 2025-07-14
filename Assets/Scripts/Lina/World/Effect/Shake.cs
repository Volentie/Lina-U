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
		private float _shake;
		private string _shakeType;
		private Vector3 _initialRotation;

		void Awake()
		{
			_initialRotation = transform.localEulerAngles;
		}

		void Update()
		{
			if (_isShaking)
			{
				switch (_shakeType)
				{
					case "roll":
						_shake = Mathf.Sin(Time.time * ShakeSpeed) * ShakeMagnitude;
						break;
				}
				transform.localEulerAngles = _initialRotation + new Vector3(0, 0, _shake);
			}
		}

		public void StartShake(string type)
		{
			_isShaking = true;
			_shakeType = type;
		}

		public void StopShake()
		{
			_isShaking = false;
			_shake = 0f;
			transform.localEulerAngles = _initialRotation;
		}
	}
}