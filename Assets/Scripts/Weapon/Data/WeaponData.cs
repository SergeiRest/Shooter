using UnityEngine;

namespace Weapon.Data
{
    [CreateAssetMenu(menuName = "Settings/Data/" + nameof(WeaponData), fileName = nameof(WeaponData))]
    public class WeaponData : ScriptableObject, IWeaponData
    {
        [SerializeField] private WeaponArgs _args;
        [SerializeField] private string _bulletId;
        [SerializeField] private string _weaponId;
        [SerializeField] private WeaponContext _prefab;

        public WeaponContext Prefab => _prefab;
        public WeaponArgs Args => _args;
        public string WeaponId => _weaponId;
        public string BulletId => _bulletId;

        public IWeaponData GetData()
        {
            return this;
        }
    }
}