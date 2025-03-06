using UnityEngine;

namespace Weapon.Bullets
{
    [CreateAssetMenu(menuName = "Settings/Data/" + nameof(BulletData), fileName = nameof(BulletData))]
    public class BulletData : ScriptableObject, IBulletData
    {
        [SerializeField] private string _name;
        [SerializeField] private Bullet _prefab;
        [SerializeField] private BulletArgs _bulletArgs;

        public BulletArgs BulletArgs => _bulletArgs;
        public string Name => _name;

        public Bullet Prefab => _prefab;
    }
    
    [System.Serializable]
    public struct BulletArgs
    {
        public int Damage;
        public float LifeTime;
    }
}