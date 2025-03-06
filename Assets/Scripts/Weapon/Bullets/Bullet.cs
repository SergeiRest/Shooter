using System;
using System.Collections.Generic;
using Main;
using UniRx;
using UnityEngine;

namespace Weapon.Bullets
{
    public abstract class Bullet : MonoBehaviour, IBullet
    {
        private BulletArgs _bulletArgs;
        private ReactiveCommand _onDestroy;
        private IDisposable _lifeDisposable;
        public ReactiveCommand OnDestroy => _onDestroy;

        public void Init(BulletArgs bulletArgs)
        {
            _bulletArgs = bulletArgs;
            _onDestroy = new ReactiveCommand();
            Init();
        }

        public void Init()
        {
            gameObject.SetActive(true);
            _lifeDisposable = Observable.Timer(_bulletArgs.LifeTime.ToSec()).Subscribe(_ =>
            {
                Destroy();
            }).AddTo(gameObject);
        }

        public void Destroy()
        {
            _lifeDisposable?.Dispose();
            gameObject.SetActive(false);
            OnDeath();
        }

        protected virtual void OnDeath()
        {
            OnDestroy?.Execute();
        }
    }
}