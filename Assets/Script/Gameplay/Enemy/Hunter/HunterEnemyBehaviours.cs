using SotongStudio.Bomber.Gameplay.Enemy.Behaviour;
using UnityEngine;
using UnityEngine.AI;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.Enemy
{
    public interface IHunterEnemyBehaviour
    {
        void StartBehaviour();
        void InternalSetup();
        HuntBehaviourLogic HuntBehaviour { get; }
        RoamingBehaviourLogic RoamingBehaviour { get; }
    }
    public class HunterEnemyBehaviours : MonoBehaviour, IHunterEnemyBehaviour
    {
        [SerializeField]
        private HuntBehaviourComponent _huntBehavComponent;
        [SerializeField]
        private RoamingBehaviourComponent _roamBehavComponent;
        public NavMeshAgent _handledAgent;
        
        private HuntBehaviourLogic _huntBehaviour;
        private RoamingBehaviourLogic _roamBehaviour;

        public HuntBehaviourLogic HuntBehaviour
        {
            get
            {
                _huntBehaviour ??= new(_huntBehavComponent);
                return _huntBehaviour;
            }
        }
        public RoamingBehaviourLogic RoamingBehaviour
        {
            get
            {
                _roamBehaviour ??= new(_roamBehavComponent);
                return _roamBehaviour;
            }
        }

        public void InternalSetup()
        {
            HuntBehaviour.OnDoneHunt.AddListener(RoamingBehaviour.RoamingProcess);
            HuntBehaviour.OnPreHunt.AddListener(RoamingBehaviour.StopRoamingProcess);
        }

        public void StartBehaviour()
        {
            RoamingBehaviour.RoamingProcess();
        }
    }
}
