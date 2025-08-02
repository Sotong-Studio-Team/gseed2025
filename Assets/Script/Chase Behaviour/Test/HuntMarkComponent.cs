using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.Enemy.Behaviour
{
    public class HuntMarkComponent : MonoBehaviour, IHuntTarget
    {
        Transform IHuntTarget.Transform => transform;
    }
}
