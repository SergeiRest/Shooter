using System;
using Main.NPC;
using UniRx;

namespace Main.StateMachine.States
{
    public class MoveState : BaseState
    {
        private IDisposable _moveDisposable;
        private INpcMover _mover;
        public MoveState(IStateMachine stateMachine, INpcMover mover) : base(stateMachine)
        {
            _mover = mover;
        }

        protected override void OnEnter()
        {
            _moveDisposable = _mover.PathReached.Subscribe(PathReached).AddTo(_mover.Main);
            FindPath();
        }

        private void FindPath()
        {
            _mover.SetPath();
        }

        protected override void OnExit()
        {
            _mover.BreakPath();
            _moveDisposable?.Dispose();
        }

        private void PathReached(Unit _)
        {
            FindPath();
        }
    }
}