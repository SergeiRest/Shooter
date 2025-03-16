namespace Main.StateMachine.States
{
    public abstract class BaseState : IState
    {
        private IStateMachine _stateMachine;
        public IStateMachine StateMachine => _stateMachine;
        
        public BaseState(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            OnEnter();
        }

        public void Exit()
        {
            OnExit();
        }

        protected virtual void OnEnter()
        {
            
        }

        protected virtual void OnExit()
        {
            
        }

    }
}