using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using Object = UnityEngine.Object;

namespace Weapon.Bullets
{
    public interface IBulletFactory
    {
        public Bullet GetBullet(string name);
    }

    public class BulletFactory : IBulletFactory, IDisposable
    {
        private readonly IBulletData[] _bulletDatas;
        private Dictionary<string, Queue<Bullet>> _bulletsDictionary;
        
        public BulletFactory(IWeaponStorage weaponStorage)
        {
            _bulletDatas = weaponStorage.Bullets.ToArray();

            _bulletsDictionary = new();
            foreach (var data in _bulletDatas)
            {
                _bulletsDictionary.Add(data.Name, new Queue<Bullet>());
            }
        }
        public Bullet GetBullet(string name)
        {
            if (_bulletDatas.Count(x => x.Name == name) <= 0)
            {
                return null;
            }

            if (!_bulletsDictionary.TryGetValue(name, out Queue<Bullet> queue))
            {
                throw new NullReferenceException($"None queue for {name} bullet");
            }

            if (TryDequeue(ref queue, out Bullet bullet))
            {
                bullet.Init();
                return bullet;
            }
            
            
            IBulletData selected = _bulletDatas.First(x => x.Name == name);
            Bullet newBullet = Object.Instantiate(selected.Prefab);
            newBullet.Init(selected.BulletArgs, selected.Speed);
            newBullet.OnDestroy.Subscribe(_ =>
            {
                queue.Enqueue(newBullet);
            }).AddTo(newBullet);
            
            return newBullet;
        }

        private bool TryDequeue(ref Queue<Bullet> queue, out Bullet bullet)
        {
            if (queue.TryDequeue(out bullet))
            {
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            foreach (var pair in _bulletsDictionary)
            {
                pair.Value.Clear();
            }
            
            _bulletsDictionary.Clear();
        }
    }
}