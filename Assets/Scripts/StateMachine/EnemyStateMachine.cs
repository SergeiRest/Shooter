using System;
using System.Collections.Generic;
using Main.NPC;
using Main.StateMachine.States;
using UnityEngine;
using UnityEngine.AI;
using VContainer;

namespace Main.StateMachine
{
    public class EnemyStateMachine : IStateMachine
    {
        private Component _component;
        private Dictionary<Type, IState> _states = new Dictionary<Type, IState>(); 
        private IState _currentState;
        
        public Component Main => _component;
        
        public EnemyStateMachine(INpcMover mover, Component main)
        {
            _component = main;
            
            IdleState idle = new IdleState(this);
            MoveState moveState = new MoveState(this, mover);

            _states.Add(idle.GetType(), idle);
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

        public void Inject(IObjectResolver resolver)
        {
            foreach (var state in _states)
            {
                resolver.Inject(state.Value);
            }
        }
    }
}