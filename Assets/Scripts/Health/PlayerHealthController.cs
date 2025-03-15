using Main.Damage;
using Modules.UI;
using UniRx;
using VContainer;

namespace Health
{
    public class PlayerHealthController : IHealthController
    {
        private const int _maxHealth = 100;
        private HealthModel _model;
        private PlayerHealthView _healthView;
        private ReactiveCommand _onDeath;
        private CompositeDisposable _compositeDisposable;

        ReactiveCommand IHealthController.OnDeath => _onDeath;

        public PlayerHealthController()
        {
            _onDeath = new ReactiveCommand();
            _compositeDisposable = new CompositeDisposable();
            _model = new HealthModel(_maxHealth);
        }
        
        [Inject]
        private void Construct(IUIContainer uiContainer)
        {
            _model.Health.Where(x => x <= 0).Subscribe(_ =>
            {
                _onDeath?.Execute();
            });
            _healthView = uiContainer.GetUI<PlayerHealthView>();
            _model.Health.Subscribe(_healthView.SetAmount).AddTo(_compositeDisposable);
        }
        
        public void DoDamage(DamageArgs value)
        {
            _model.TakeDamage(value.Damage);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}