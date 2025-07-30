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

        [Button]
        private void Setup()
        {
            _huntBehaviour = new(_huntBehaviourComponent);
        }
    }
}
