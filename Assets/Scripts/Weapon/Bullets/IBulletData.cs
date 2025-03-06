namespace Weapon.Bullets
{
    public interface IBulletData
    {
        public string Name { get; }
        public Bullet Prefab { get; }
    }
}