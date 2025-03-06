using UnityEngine;

namespace Weapon.Bullets
{
    public abstract class Bullet : MonoBehaviour, IBullet
    {
        public virtual void Destroy()
        {
            Destroy(gameObject);
        }
    }
}