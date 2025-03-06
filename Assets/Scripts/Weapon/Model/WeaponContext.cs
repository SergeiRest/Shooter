using UnityEngine;

namespace Weapon
{
    public class WeaponContext : MonoBehaviour
    {
        [field: SerializeField] public Transform BulletPoint { get; private set; }
    }
}