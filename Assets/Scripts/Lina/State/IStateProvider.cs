using System;

namespace Lina.State
{
    public interface IStateProvider<TState>
    {
        TState CurrentState { get; }

        void SetState(TState state);

        event Action<TState> OnStateChanged;
    }
}