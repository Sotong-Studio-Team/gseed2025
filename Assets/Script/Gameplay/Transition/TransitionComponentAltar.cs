using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.Transition
{
    public class TransitionComponentAltar : MonoBehaviour
    {
        [Header("Altar")]
        [SerializeField]
        public Collider2D CameraBound;
        public Transform SpawnPos;
    }
}
