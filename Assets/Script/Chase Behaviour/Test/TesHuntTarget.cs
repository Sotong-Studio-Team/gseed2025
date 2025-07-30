using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.Enemy.Behaviour.Test
{
    public class TesHuntTarget : MonoBehaviour, IHuntTarget
    {
        Transform IHuntTarget.Transform => transform;
    }
}
