using System;
using System.Collections.Generic;
using Main.NPC;
using Main.StateMachine.States;
using UnityEngine.AI;

namespace Main.StateMachine
{
    public class EnemyStateMachine : IStateMachine
    {
        private Dictionary<Type, IState> _states = new Dictionary<Type, IState>(); 
        private IState _currentState;

        public EnemyStateMachine(INpcMover mover)
        {
            MoveState moveState = new MoveState(this, mover);
            
            _states.Add(moveState.GetType(), moveState);
        }
        
        public void SetState<TState>() where TState : IState
        {
            Type key = typeof(TState);
            if (_states.TryGetValue(key, out IState state))
            {
                _currentState?.Exit();
                _currentState = state;
                _currentState.Enter();
            }
            else
            {
                throw new NullReferenceException($"None state of type {key}");
            }
        }
    }
}