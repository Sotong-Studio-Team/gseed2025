using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

namespace SotongStudio.Bomber.Gameplay.Transition
{
    public class TransitionComponent : MonoBehaviour
    {
        [Header("General")]
        public Transform TransitionImage;
        public CinemachineConfiner2D ConfinerCamera;
        public CanvasGroup TransitionCanvasGroup;
        public Collider2D MainMapCameraBound;
    }
}
