using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace SotongStudio.Bomber.Gameplay.Enemy.Behaviour
{
    public class HuntBehaviourLogic
    {
        public readonly IHuntBehaviourComponent _huntComponent;
        private CancellationTokenSource _huntCts;
        private IHuntTarget _currentTarget;

        public UnityEvent OnDoneHunt = new();
        public UnityEvent OnPreHunt = new();

        private readonly NavMeshPath _tempPath = new NavMeshPath();

        public HuntBehaviourLogic(IHuntBehaviourComponent chaseLogic)
        {
            _huntComponent = chaseLogic;

            _huntComponent.OnDetectTarget.AddListener(OnDetectTarget);
            _huntComponent.OnLostTarget.AddListener(OnLostTarget);
        }

        private void OnDetectTarget(IHuntTarget target)
        {
            if (target == null || !IsCanHunt(target))
            {
                CancelHuntProcess();
                _currentTarget = null;
                _huntComponent.Agent.ResetPath();
                return;
            }

            OnPreHunt?.Invoke();

            CancelHuntProcess();
            _huntCts = new CancellationTokenSource();

            _currentTarget = target;
            PeriodicCheckAsync(_huntCts.Token).Forget();

        }

        private void OnLostTarget()
        {
            CancelHuntProcess();

            _currentTarget = null;
            _huntComponent.Agent.ResetPath();

            OnDoneHunt?.Invoke();
        }

        private async UniTaskVoid PeriodicCheckAsync(CancellationToken cancellationToken)
        {
            for (int i = 0; i < 10;)
            {
                if(_currentTarget != null ||
                  !cancellationToken.IsCancellationRequested)
                {
                    await UniTask.WaitForSeconds(0.3f, cancellationToken: cancellationToken);
                    _huntComponent.Agent.SetDestination(_currentTarget.Transform.position);
                }
            }
        }

        private void CancelHuntProcess()
        {
            _huntCts?.Cancel();
            _huntCts?.Dispose();
            _huntCts = null;
        }

        private bool IsCanHunt(IHuntTarget target)
        {
            _huntComponent.Agent.CalculatePath(target.Transform.position, _tempPath);

            return _tempPath.status == NavMeshPathStatus.PathComplete;
        }
    }
}
