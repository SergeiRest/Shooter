using Modules.UI;
using UniRx;
using UnityEngine;
using VContainer;

namespace Health
{
    public class PlayerHealthController : IHealthController
    {
        private HealthModel _model;
        private PlayerHealthView _healthView;
        private ReactiveCommand _onDeath;
        private CompositeDisposable _compositeDisposable;

        ReactiveCommand IHealthController.OnDeath => _onDeath;

        public PlayerHealthController()
        {
            _compositeDisposable = new CompositeDisposable();
        }
        
        [Inject]
        private void Construct(IUIContainer uiContainer)
        {
            _model = new HealthModel(100);
            _healthView = uiContainer.GetUI<PlayerHealthView>();
            _model.Health.Subscribe(_healthView.SetAmount).AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}