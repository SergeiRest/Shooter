using UnityEngine;

namespace Weapon.Bullets
{
    [CreateAssetMenu(menuName = "Settings/Data/" + nameof(BulletData), fileName = nameof(BulletData))]
    public class BulletData : ScriptableObject, IBulletData
    {
        [SerializeField] private string _name;
        [SerializeField] private Bullet _prefab;

        public string Name => _name;

        public Bullet Prefab => _prefab;
    }
}