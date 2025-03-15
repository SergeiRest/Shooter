using Main.Damage;
using UniRx;

namespace Health
{
    public interface IHealthController
    {
        public ReactiveCommand OnDeath {get;}

        public void DoDamage(DamageArgs value);
    }
}