using System.Linq;
using Modules.UI;
using UnityEngine;
using VContainer.Unity;

namespace Weapon
{
    public interface IWeaponFactory
    {
        public WeaponContext GetWeapon(string name);
    }
    public class WeaponFactory : IWeaponFactory, IInitializable
    {
        private readonly IWeaponStorage _weaponStorage;

        public WeaponFactory(IWeaponStorage weaponStorage)
        {
            _weaponStorage = weaponStorage;
        }
        
        public WeaponContext GetWeapon(string name)
        {
            if (_weaponStorage.Weapons.Count(x => x.WeaponId == name) <= 0)
            {
                Debug.LogError($"Not contains weapon {name}");
                return null;
            }

            WeaponContext prefab = _weaponStorage.Weapons.First(x => x.WeaponId == name).Prefab;
            return Object.Instantiate(prefab);
        }

        public void Initialize()
        {
            Debug.Log(_weaponStorage.Weapons.Count);
        }
    }
}