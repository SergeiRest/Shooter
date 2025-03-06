using UniRx;

namespace Weapon.Bullets
{
    public interface IBullet
    {
        public ReactiveCommand OnDestroy { get; }
        public void Init(BulletArgs bulletArgs);
        public void Init();
        public void Destroy();
    }
}