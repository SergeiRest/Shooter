using System.Collections.Generic;
using Weapon.Bullets;
using Weapon.Data;

namespace Weapon
{
    public interface IWeaponStorage
    {
        public IReadOnlyList<WeaponData> Weapons { get; }
        public IReadOnlyList<IBulletData> Bullets { get; }
    }
}