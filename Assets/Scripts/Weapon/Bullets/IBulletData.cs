namespace Weapon.Bullets
{
    public interface IBulletData
    {
        public BulletArgs BulletArgs { get; }
        public string Name { get; }
        public Bullet Prefab { get; }
    }
}