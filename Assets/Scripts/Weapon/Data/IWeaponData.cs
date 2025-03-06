namespace Weapon.Data
{
    public interface IWeaponData
    {
        public WeaponContext Prefab { get; }
        public int MaxBullets { get; }
        public float Cooldown { get; }
        public string WeaponId { get; }
        public string BulletId { get; }
        public IWeaponData GetData();
    }
}