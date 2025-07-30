using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.Enemy.Behaviour
{
    public class HuntBehaviourLogic
    {
        public readonly IHuntBehaviourComponent _huntComponent;
        private CancellationTokenSource _huntCts;
        private IHuntTarget _currentTarget;
        private bool _isCanHunt;

        public HuntBehaviourLogic(IHuntBehaviourComponent chaseLogic)
        {
            _huntComponent = chaseLogic;

            _huntComponent.OnDetectTarget.AddListener(OnDetectTarget);
            _huntComponent.OnLostTarget.AddListener(OnLostTarget);
        }

        public void SetCanHunt(bool isCanHunt)
        {
            _isCanHunt = isCanHunt;

            if (!_isCanHunt)
            {
                CancelHuntProcess();
                _currentTarget = null;
                _huntComponent.NavAgentHandled.ResetPath();
            }
            else
            {
                if (_currentTarget == null) { return; }

                CancelHuntProcess();
                _huntCts = new CancellationTokenSource();

                PeriodicCheckAsync(_huntCts.Token).Forget();
            }
        }

        private void OnDetectTarget(IHuntTarget target)
        {
            if (!_isCanHunt)
            {
                return;
            }

            CancelHuntProcess();
            _huntCts = new CancellationTokenSource();

            _currentTarget = target;
            PeriodicCheckAsync(_huntCts.Token).Forget();

        }

        private void OnLostTarget()
        {
            CancelHuntProcess();

            _currentTarget = null;
            _huntComponent.NavAgentHandled.ResetPath();
        }

        private async UniTaskVoid PeriodicCheckAsync(CancellationToken cancellationToken)
        {
            if (_currentTarget != null) { return; }

            while (_currentTarget != null ||
                   !_huntCts.IsCancellationRequested)
            {
                await UniTask.WaitForSeconds(0.3f, cancellationToken: cancellationToken);
                _huntComponent.NavAgentHandled.SetDestination(_currentTarget.Transform.position);
            }
        }

        private void CancelHuntProcess()
        {
            _huntCts?.Cancel();
            _huntCts?.Dispose();
            _huntCts = null;
        }
    }
}
