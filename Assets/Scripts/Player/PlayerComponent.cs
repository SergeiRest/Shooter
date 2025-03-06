using UnityEngine;

namespace Player
{
    public class PlayerComponent : MonoBehaviour
    {
        [field: SerializeField] public Transform Main { get; private set; }
        [field: SerializeField] public Transform LookAtPoint { get; private set; }
        [field: SerializeField] public Transform WeaponRoot { get; private set; }
    }
}