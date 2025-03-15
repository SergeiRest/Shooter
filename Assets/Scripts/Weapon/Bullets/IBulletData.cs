using Main.Damage;

namespace Weapon.Bullets
{
    public interface IBulletData
    {
        public DamageArgs BulletArgs { get; }
        public float Speed { get; }
        public string Name { get; }
        public Bullet Prefab { get; }
    }
}