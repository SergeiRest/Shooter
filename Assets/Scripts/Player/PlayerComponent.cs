using System;
using Main.Damage;
using UnityEngine;

namespace Player
{
    public class PlayerComponent : MonoBehaviour
    {
        [field: SerializeField] public Transform Main { get; private set; }
        [field: SerializeField] public Transform LookAtPoint { get; private set; }
        [field: SerializeField] public Transform WeaponRoot { get; private set; }
        [field: SerializeField] public MonoDamageInteractable[] DamageInteractable { get; private set; }

        private void Start()
        {
            Debug.Log(LayerMask.NameToLayer("Player"));
        }
    }
}