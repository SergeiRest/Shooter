using Main.Damage;
using UniRx;

namespace Weapon.Bullets
{
    public interface IBullet
    {
        public ReactiveCommand OnDestroy { get; }
        public void Init(DamageArgs bulletArgs, float speed);
        public void Init();
        public void Destroy();
    }
}