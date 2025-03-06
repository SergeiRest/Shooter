using UnityEngine;

namespace Weapon.Data
{
    [CreateAssetMenu(menuName = "Settings/Data/" + nameof(WeaponData), fileName = nameof(WeaponData))]
    public class WeaponData : ScriptableObject, IWeaponData
    {
        [SerializeField] private int _maxBullets;
        [SerializeField] private float _cooldown;
        [SerializeField] private string _bulletId;
        [SerializeField] private string _weaponId;
        [SerializeField] private WeaponContext _prefab;

        public WeaponContext Prefab => _prefab;
        public int MaxBullets => _maxBullets;
        public float Cooldown => _cooldown;
        public string WeaponId => _weaponId;
        public string BulletId => _bulletId;

        public IWeaponData GetData()
        {
            return this;
        }
    }
}