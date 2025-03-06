using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Main;
using UniRx;
using UnityEngine;
using VContainer;
using Weapon.Bullets;
using Weapon.Data;

namespace Weapon
{
    public class BaseWeapon : IWeapon
    {
        [Inject] private IBulletFactory _bulletFactory;

        private IntReactiveProperty _bulletsCount;
        private ReactiveCommand _reload;
        private CancellationTokenSource _cts = new ();

        private WeaponArgs _args;
        private bool _isReload;
        private bool _isOnShoot;
        private string _bullet;
        private WeaponContext _weaponContext;
        private IDisposable _shootDisposable;

        public IntReactiveProperty BulletsCount => _bulletsCount;
        public ReactiveCommand ReactiveReload => _reload;

        public BaseWeapon(WeaponArgs args, string bullet, WeaponContext weaponContext)
        {
            _args = args;
            _bulletsCount = new IntReactiveProperty(_args.MaxBullets);
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

            OnShot();
        }

        public void Reload()
        {
            OnReload();
        }

        protected virtual async void OnShot()
        {
            if(_isOnShoot)
                return;

            _isOnShoot = true;
            _bulletsCount.Value--;
            Bullet bullet = _bulletFactory.GetBullet(_bullet);
            bullet.transform.position = _weaponContext.BulletPoint.position;
            bullet.transform.rotation = _weaponContext.BulletPoint.rotation;
            try
            {
                await UniTask.Delay(_args.ShootDelay.ToSec(), cancellationToken: _cts.Token);
                _isOnShoot = false;
            }
            catch (OperationCanceledException)
            {
                Debug.Log("OperationWasCancelled");
            }
        }

        protected virtual async void OnReload()
        {
            if(_isReload)
                return;

            _isReload = true;
            ReactiveReload?.Execute();
            try
            {
                await UniTask.Delay(_args.ReloadTime.ToSec(), cancellationToken: _cts.Token);
                _bulletsCount.Value = _args.MaxBullets;
                _isReload = false;
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Operation was canceled");
            }
        }

        public void Cancel()
        {
            _cts?.Cancel();
        }
    }
}