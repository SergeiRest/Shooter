using System;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Main.NPC
{
    public class NavMeshMover : INpcMover
    {
        private NavMeshAgent _agent;
        private IDisposable _disposable;
        private ReactiveCommand _pathReached;
        public ReactiveCommand PathReached => _pathReached;
        public Component Main => _agent;

        public NavMeshMover(NavMeshAgent agent)
        {
            _pathReached = new ReactiveCommand();
            _agent = agent;
        }

        
        int areaMask = 1 << NavMesh.GetAreaFromName("Walkable");

        public void SetPath()
        {
            float range = 50;
            Vector3 randomPoint = _agent.transform.position + Random.insideUnitSphere * range; 
            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, range, areaMask))
            {
                _agent.SetDestination(hit.position);
                SetObservable();
            }
        }

        private void SetObservable()
        {
            _disposable = Observable.EveryLateUpdate().Subscribe(_ =>
            {
                if (_agent.remainingDistance <= 0)
                {
                    _agent.ResetPath();
                    PathReached?.Execute();
                    _disposable?.Dispose();
                }
            });   
        }

        public void BreakPath()
        {
            if (_agent.hasPath)
            {
                _agent.ResetPath();
            }
            _disposable?.Dispose();
        }
    }
}