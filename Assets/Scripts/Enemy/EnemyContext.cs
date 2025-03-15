using Health.Enemy;
using Main.Damage;
using UnityEngine;

public class EnemyContext : MonoBehaviour
{
    [field: SerializeField] public EnemyHealthView HealthView { get; private set; }
    [field: SerializeField] public MonoDamageInteractable[] interactables;
}
