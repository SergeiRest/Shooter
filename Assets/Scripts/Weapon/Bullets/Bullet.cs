using System;
using System.Collections.Generic;
using Main;
using Main.Damage;
using UniRx;
using UnityEngine;

namespace Weapon.Bullets
{
    public abstract class Bullet : MonoBehaviour, IBullet
    {
        private DamageArgs _bulletArgs;
        private float _speed;
        private ReactiveCommand _onDestroy;
        private IDisposable _lifeDisposable;
        public ReactiveCommand OnDestroy => _onDestroy;

        public void Init(DamageArgs bulletArgs, float speed)
        {
            _bulletArgs = bulletArgs;
            _speed = speed;
            _onDestroy = new ReactiveCommand();
            Init();
        }
        
        private void FixedUpdate()
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageInteractable interactable))
            {
                OnInteract(interactable);
            }
            
            Destroy();
        }

        protected virtual void OnInteract(IDamageInteractable interactable)
        {
            interactable.TakeDamage(_bulletArgs);
        }
    }
}