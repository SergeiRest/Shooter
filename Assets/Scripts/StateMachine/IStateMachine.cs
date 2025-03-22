using UnityEngine;
using VContainer;

namespace Main.StateMachine
{
    public interface IStateMachine
    {
        public Component Main { get; }
        public void SetState<TState>() where TState : IState;
        public void Inject(IObjectResolver resolver);
    }

    public interface IState
    {
        public IStateMachine StateMachine { get; }

        public void Enter();
        public void Exit();
    }
}