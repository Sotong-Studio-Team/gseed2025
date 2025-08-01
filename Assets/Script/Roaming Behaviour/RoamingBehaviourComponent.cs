using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace SotongStudio.Bomber.Gameplay.Enemy.Behaviour
{
    public interface IRoamingBehaviourComponent
    {
        UnityEvent OnReachDestination { get; }
        Transform Transfom { get; }
        NavMeshAgent Agent { get; }
        float RadiusArea { get; }
    }

    public class RoamingBehaviourComponent : MonoBehaviour, IRoamingBehaviourComponent
    {
        [SerializeField]
        private NavMeshAgent _navAgent;

        [SerializeField]
        private CircleCollider2D _walkRadius;

        public Transform Transfom => this.transform;

        public NavMeshAgent Agent => _navAgent;

        public float RadiusArea => _walkRadius.radius;

        public UnityEvent OnReachDestination { get; private set; } = new();

       
    }
}
