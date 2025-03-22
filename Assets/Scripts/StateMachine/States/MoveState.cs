using System;
using Cysharp.Threading.Tasks;
using Main.NPC;
using Main.Overlap;
using UniRx;
using UnityEngine;
using VContainer;

namespace Main.StateMachine.States
{
    public class IdleState : BaseState
    {
        [Inject] private IOverlapService _overlapService;
        
        public IdleState(IStateMachine stateMachine) : base(stateMachine)
        {
            
        }
        
        protected override async void OnEnter()
        {
            base.OnEnter();
            _overlapService.OverlapSphere(StateMachine.Main.transform.position, 15, LayerMasks.Player);
            await UniTask.Delay(3f.ToSec());
            StateMachine.SetState<MoveState>();
        }
    }
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
            StateMachine.SetState<IdleState>();
        }
    }
}