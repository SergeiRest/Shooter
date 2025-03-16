using Health;
using Health.Enemy;
using Main.NPC;
using Main.StateMachine;
using Main.StateMachine.States;
using VContainer;

namespace Main.Enemy
{
    public interface IEnemy
    {
        
    }

    public class Enemy : IEnemy
    {
        private EnemyContext _context;
        private IHealthController _healthController;
        private INpcMover _mover;
        private IStateMachine _stateMachine;
        
        public Enemy(EnemyContext context)
        {
            _context = context;
            _healthController = new EnemyHealthController(_context.HealthView);
            _mover = new NavMeshMover(context.agent);
            _stateMachine = new EnemyStateMachine(_mover);
            
            foreach (var interactable in _context.interactables)
            {
                interactable.Init(_healthController);
            }
            
            _stateMachine.SetState<MoveState>();
            
        }
    }
    
}