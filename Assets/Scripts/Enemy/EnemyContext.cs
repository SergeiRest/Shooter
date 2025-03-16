using Health.Enemy;
using Main.Damage;
using UnityEngine;
using UnityEngine.AI;

public class EnemyContext : MonoBehaviour
{
    [field: SerializeField] public EnemyHealthView HealthView { get; private set; }
    [field: SerializeField] public MonoDamageInteractable[] interactables { get; private set; }
    [field: SerializeField] public NavMeshAgent agent { get; private set; }
}
