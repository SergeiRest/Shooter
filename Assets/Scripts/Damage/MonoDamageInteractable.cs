using Health;
using UnityEngine;

namespace Main.Damage
{
    public class MonoDamageInteractable : MonoBehaviour, IDamageInteractable
    {
        private IHealthController _healthController;
        
        public void Init(IHealthController healthController)
        {
            _healthController = healthController;
        }

        public void TakeDamage(DamageArgs args)
        {
            _healthController.DoDamage(args);
        }
    }
}