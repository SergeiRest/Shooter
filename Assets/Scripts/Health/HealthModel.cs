using UniRx;
using UnityEngine;

namespace Health
{
    public class HealthModel
    {
        private IntReactiveProperty _health;

        public IntReactiveProperty Health => _health;
        public HealthModel(int amount)
        {
            _health = new IntReactiveProperty(amount);
        }

        public void TakeDamage(int value)
        {
            value = Mathf.Clamp(value, 0, int.MaxValue);
            _health.Value -= value;
        }
    }
}