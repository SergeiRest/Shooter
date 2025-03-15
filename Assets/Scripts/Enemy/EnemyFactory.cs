using VContainer;
using VContainer.Unity;

namespace Main.Enemy
{
    public interface IEnemyFactory
    {
    
    }
    
    public class EnemyFactory : IEnemyFactory, IStartable
    {
        private EnemyContext[] _contexts;
        private IObjectResolver _resolver;
        
        public EnemyFactory(IObjectResolver resolver, EnemyContext[] contexts)
        {
            _resolver = resolver;
            _contexts = contexts;
        }

        public void Start()
        {
            foreach (var context in _contexts)
            {
                IEnemy enemy = new Enemy(context);
                _resolver.Inject(enemy);
            }
        }
    }
}