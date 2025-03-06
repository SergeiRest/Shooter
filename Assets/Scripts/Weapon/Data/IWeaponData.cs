namespace Weapon.Data
{
    public interface IWeaponData
    {
        public WeaponContext Prefab { get; }
        public WeaponArgs Args {get;}
        public string WeaponId { get; }
        public string BulletId { get; }
        public IWeaponData GetData();
    }

    [System.Serializable]
    public struct WeaponArgs
    {
        public int MaxBullets;
        public float ReloadTime;
        public float ShootDelay;
    }
}