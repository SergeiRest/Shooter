using Main.Damage;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Health.Enemy
{
    public class EnemyHealthController : IHealthController
    {
        private const int _maxHealth = 100;
        private HealthModel _healthModel;
        private EnemyHealthView _healthView;

        private ReactiveCommand _onDeath;
        public ReactiveCommand OnDeath => _onDeath;

        public EnemyHealthController(EnemyHealthView healthView)
        {
            _onDeath = new ReactiveCommand();
            _healthModel = new HealthModel(_maxHealth);
            _healthView = healthView;
            _healthModel.Health.Subscribe(UpdateHealth);
        }

        private void UpdateHealth(int value)
        {
            float amount = (float)value / _maxHealth;
            amount = Mathf.Clamp01(amount);
            _healthView.Fill(amount);

            if (amount <= 0)
            {
                _onDeath?.Execute();
            }
        }
        
        public void DoDamage(DamageArgs value)
        {
            _healthModel.TakeDamage(value.Damage);
        }
    }
}