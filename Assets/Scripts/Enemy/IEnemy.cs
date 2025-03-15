using Health;
using Health.Enemy;
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
        
        public Enemy(EnemyContext context)
        {
            _context = context;
            _healthController = new EnemyHealthController(_context.HealthView);
            foreach (var interactable in _context.interactables)
            {
                interactable.Init(_healthController);
            }
        }
    }
    
}