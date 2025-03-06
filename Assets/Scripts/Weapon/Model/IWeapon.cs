using UniRx;

namespace Weapon
{
    public interface IWeapon
    {
        public IntReactiveProperty BulletsCount { get; }
        public ReactiveCommand ReactiveReload { get; }
        public void Shot();
        public void Reload();
    }
}