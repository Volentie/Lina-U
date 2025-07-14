using System.Collections;
using Lina.Player.Object;
using UnityEngine;

namespace Lina.World
{
    /// <summary>
    /// A simple door that can be opened and closed.
    /// </summary>
    public class Door : MonoBehaviour, IInteractable
    {
        [Header("Door Settings")]
        [SerializeField] private float _animationTime = 0.5f;
        [SerializeField] private float _openAngle = 90.0f;

        private bool _isOpen = false;
        private bool _isAnimating = false;
        private Vector3 _closedRotation;
        private Vector3 _openRotation;

        void Awake()
        {
            _closedRotation = transform.localEulerAngles;
            _openRotation = new Vector3(_closedRotation.x, _closedRotation.y + _openAngle, _closedRotation.z);
        }

        public void Interact()
        {
            if (_isAnimating)
                return;

            _isOpen = !_isOpen;
            StartCoroutine(AnimateDoor());
        }

        private IEnumerator AnimateDoor()
        {
            _isAnimating = true;

            Quaternion startRotation = transform.localRotation;
            Quaternion endRotation = _isOpen ? Quaternion.Euler(_openRotation) : Quaternion.Euler(_closedRotation);

            float time = 0;
            while (time < 1)
            {
                transform.localRotation = Quaternion.Slerp(startRotation, endRotation, time);
                time += Time.deltaTime / _animationTime;
                yield return null;
            }

            transform.localRotation = endRotation;
            _isAnimating = false;
        }
    }
}