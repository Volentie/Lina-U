using System;
using UnityEngine;
using System.Collections.Generic;

namespace Lina.State
{
    /// <summary>
    /// Generic MonoBehaviour that holds a state of type TState (an enum) and broadcasts changes.
    /// </summary>
    /// <typeparam name="TState">Any enum type representing your states.</typeparam>
    public class StateProvider<TState> : MonoBehaviour, IStateProvider<TState>
        where TState : struct, Enum
    {
        [Tooltip("Initial state for this provider")]
        [SerializeField] 
        private TState _initialState;

        public TState CurrentState { get; private set; }

        public event Action<TState> OnStateChanged;

        protected virtual void Awake()
        {
            // Initialize to the inspector-set value
            CurrentState = _initialState;
        }

        public void SetState(TState newState)
        {
            if (EqualityComparer<TState>.Default.Equals(newState, CurrentState))
                return;

            CurrentState = newState;
            OnStateChanged?.Invoke(newState);
        }
    }
}
