using UniRx;

namespace Health
{
    public interface IHealthController
    {
        public ReactiveCommand OnDeath {get;}
    }
}