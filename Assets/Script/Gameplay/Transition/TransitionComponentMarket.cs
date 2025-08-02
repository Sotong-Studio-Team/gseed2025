using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.Transition
{
    public class TransitionComponentMarket : MonoBehaviour
    {
        [Header("Market")]
        [SerializeField]
        public Collider2D CameraBound;
        public Transform SpawnPos;
    }
}
