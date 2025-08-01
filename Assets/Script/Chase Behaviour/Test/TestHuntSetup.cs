using NaughtyAttributes;
using SotongStudio.Bomber.Gameplay.Enemy.Behaviour;
using UnityEngine;

namespace SotongStudio.Bomber
{
    public class TestHuntSetup : MonoBehaviour
    {
        [SerializeField]
        private HuntBehaviourComponent _huntBehaviourComponent;
        private HuntBehaviourLogic _huntBehaviour;

        [SerializeField]
        private RoamingBehaviourComponent _roamingBehaviourComponent;
        private RoamingBehaviourLogic _roamingBehaviourLogic;

        [Button]
        private void Setup()
        {
            _huntBehaviour = new(_huntBehaviourComponent);
            _roamingBehaviourLogic = new(_roamingBehaviourComponent);

            _huntBehaviour.OnDoneHunt.AddListener(_roamingBehaviourLogic.RoamingProcess);
            _huntBehaviour.OnPreHunt.AddListener(_roamingBehaviourLogic.StopRoamingProcess);

            _roamingBehaviourLogic.RoamingProcess();
        }
    }
}
