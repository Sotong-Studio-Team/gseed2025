using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using UnityEngine.AI;

namespace SotongStudio.Bomber.Gameplay.Enemy.Behaviour
{
    public interface IRoamingBehaviourLogic
    {
        void RoamingProcess();
        void StopRoamingProcess();
    }
    public class RoamingBehaviourLogic : IRoamingBehaviourLogic
    {
        private readonly IRoamingBehaviourComponent _roamingBehaviourComponent;
        private readonly NavMeshPath _tempPath = new();
        private CancellationTokenSource _roamingCts;

        private readonly float _delayNewDestination;

        public RoamingBehaviourLogic(RoamingBehaviourComponent roamingBehaviourComponent)
        {
            _roamingBehaviourComponent = roamingBehaviourComponent;

            _delayNewDestination = Random.Range(3f, 5f);
        }


        public void RoamingProcess()
        {
            CancelRoaming();
            _roamingCts = new CancellationTokenSource();

            SetNewDestination();
            GetNewDestinationAsync(_roamingCts.Token).Forget();
        }

        private async UniTaskVoid GetNewDestinationAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await UniTask.WaitForSeconds(_delayNewDestination);
                SetNewDestination();
            }
        }
        private void SetNewDestination()
        {
            var destination = GetWalkDestination();
            Debug.Log($"Set New Dest :{destination}");
            _roamingBehaviourComponent.Agent.SetDestination(destination);

        }

        private Vector3 GetWalkDestination()
        {
            var startPos = _roamingBehaviourComponent.Transfom.position;
            var radius = _roamingBehaviourComponent.RadiusArea;

            var destX = Random.Range((int)-radius, (int)radius);
            var destY = Random.Range((int)-radius, (int)radius);

            var destination = new Vector3(startPos.x + destX,
                                          startPos.y + destY,
                                          startPos.z);

            if (_roamingBehaviourComponent.Agent.CalculatePath(destination, _tempPath))
            {
                return destination;
            }
            return startPos;

        }

        public void StopRoamingProcess()
        {
            CancelRoaming();
            _roamingBehaviourComponent.Agent.ResetPath();
        }

        private void CancelRoaming()
        {
            _roamingCts?.Cancel();
            _roamingCts?.Dispose();
            _roamingCts = null;

        }
    }
}

