namespace Main.StateMachine
{
    public interface IStateMachine
    {
        public void SetState<TState>() where TState : IState;
    }

    public interface IState
    {
        public IStateMachine StateMachine { get; }

        public void Enter();
        public void Exit();
    }
}