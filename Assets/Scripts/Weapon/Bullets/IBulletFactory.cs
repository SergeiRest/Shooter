using System.Linq;
using UnityEngine;

namespace Weapon.Bullets
{
    public interface IBulletFactory
    {
        public Bullet GetBullet(string name);
    }

    public class BulletFactory : IBulletFactory
    {
        private readonly IBulletData[] _bulletDatas;
        public BulletFactory(IWeaponStorage weaponStorage)
        {
            _bulletDatas = weaponStorage.Bullets.ToArray();
        }
        public Bullet GetBullet(string name)
        {
            if (_bulletDatas.Count(x => x.Name == name) <= 0)
            {
                return null;
            }

            IBulletData selected = _bulletDatas.First(x => x.Name == name);

            return Object.Instantiate(selected.Prefab);
        }
    }
}