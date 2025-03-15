using Main.Damage;
using UnityEngine;

namespace Weapon.Bullets
{
    [CreateAssetMenu(menuName = "Settings/Data/" + nameof(BulletData), fileName = nameof(BulletData))]
    public class BulletData : ScriptableObject, IBulletData
    {
        [SerializeField] private string _name;
        [SerializeField] private Bullet _prefab;
        [SerializeField] private DamageArgs _bulletArgs;
        [SerializeField] private float _speed;

        public DamageArgs BulletArgs => _bulletArgs;
        public string Name => _name;

        public Bullet Prefab => _prefab;
        public float Speed => _speed;
    }
}