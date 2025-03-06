using UniRx;
using VContainer;
using Weapon.Bullets;

namespace Weapon
{
    public class BaseWeapon : IWeapon
    {
        [Inject] private IBulletFactory _bulletFactory;

        private IntReactiveProperty _bulletsCount;
        private ReactiveCommand _reload;

        private bool _isReload;
        private int _maxBullets;
        private string _bullet;
        private WeaponContext _weaponContext;

        public IntReactiveProperty BulletsCount => _bulletsCount;
        public ReactiveCommand ReactiveReload => _reload;

        public BaseWeapon(int bulletsCount, string bullet, WeaponContext weaponContext)
        {
            _maxBullets = bulletsCount;
            _bulletsCount = new IntReactiveProperty(bulletsCount);
            _bullet = bullet;
            _weaponContext = weaponContext;
            _reload = new ReactiveCommand();
        }


        public void Shot()
        {
            if (_bulletsCount.Value <= 0)
            {
                Reload();
                return;
            }

            _bulletsCount.Value--;
            OnShot();
        }

        public void Reload()
        {
            
        }

        protected virtual void OnShot()
        {
            Bullet bullet = _bulletFactory.GetBullet(_bullet);
            bullet.transform.position = _weaponContext.BulletPoint.position;
            bullet.transform.rotation = _weaponContext.BulletPoint.rotation;
        }

        protected virtual void OnReload()
        {
            if(_isReload)
                return;

            _isReload = true;
        }
    }
}