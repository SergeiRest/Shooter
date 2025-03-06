using System.Collections.Generic;
using UnityEngine;
using Weapon.Bullets;
using Weapon.Data;

namespace Weapon
{
    [CreateAssetMenu(menuName = "Settings/Data/" + nameof(WeaponStorage), fileName = nameof(WeaponStorage))]
    public class WeaponStorage : ScriptableObject, IWeaponStorage
    {
        [SerializeField] private WeaponData[] _weapons;
        [SerializeField] private BulletData[] _bullets;

        public IReadOnlyList<WeaponData> Weapons => _weapons;
        public IReadOnlyList<IBulletData> Bullets => _bullets;
    }
}