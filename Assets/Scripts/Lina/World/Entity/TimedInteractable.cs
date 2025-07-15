using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Lina.World.Entity
{
	/// <summary>
	/// Entity that takes some time to trigger and does something when activated
	/// </summary>
	public class TimedInteractable : MonoBehaviour, IInteractable
	{
		[Header("Animation")]
		[SerializeField]
		private float _timeToActivate = 10f;

		bool IsWaiting = true;
		[Header("Events")]
		[Tooltip("Fired after the delay has passed. Use this to start effects like sound or animation.")]
		public UnityEvent OnActivated;

		[Tooltip("Fired when the player interacts with this object while it's active.")]
		public UnityEvent OnTrigger;

		void Start()
		{
			StartCoroutine(ActivateAfterDelay());
		}

		private IEnumerator ActivateAfterDelay()
		{
			yield return new WaitForSeconds(_timeToActivate);
			IsWaiting = false;
			OnActivated.Invoke();
		}

		public void Interact()
		{
			if (!IsWaiting)
			{
				OnTrigger.Invoke();
				IsWaiting = true;
			}
		}
		
	}
}