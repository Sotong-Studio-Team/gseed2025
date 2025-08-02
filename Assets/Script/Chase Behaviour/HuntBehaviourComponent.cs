using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace SotongStudio.Bomber.Gameplay.Enemy.Behaviour
{
    public interface IHuntBehaviourComponent
    {
        UnityEvent<IHuntTarget> OnDetectTarget { get; }
        UnityEvent OnLostTarget { get; }

        NavMeshAgent Agent { get; }
    }
    public class HuntBehaviourComponent : MonoBehaviour, IHuntBehaviourComponent
    {
        [SerializeField]
        private NavMeshAgent _navmeshAgent;

        private IHuntTarget _currentHandledTarget;

        public UnityEvent<IHuntTarget> OnDetectTarget { get; private set; } = new();
        public UnityEvent OnLostTarget { get; private set; } = new();
        public NavMeshAgent Agent => _navmeshAgent;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<IHuntTarget>(out var target))
            {
                _currentHandledTarget = target;
                OnDetectTarget?.Invoke(target);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<IHuntTarget>(out var target)
                && target == _currentHandledTarget)
            {
                _currentHandledTarget = null;
                OnLostTarget?.Invoke();
            }
        }


    }
}
