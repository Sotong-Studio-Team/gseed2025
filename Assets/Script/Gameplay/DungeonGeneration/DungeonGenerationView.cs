using NavMeshPlus.Components;
using SotongStudio.Bomber.Gameplay.DungeonObject;
using UnityEngine;

namespace SotongStudio.Bomber
{
    public interface IDungeonGenerationView
    {
        Transform[] ClusterSlots { get; }

        DungeonObject HardWall { get; }
        DungeonObject SoftWall { get; }
        Transform ObjectContainer { get; }

        NavMeshSurface NavigationSurface { get; }
    }
    public class DungeonGenerationView : MonoBehaviour, IDungeonGenerationView
    {
        [SerializeField]
        private Transform[] _clusterSlots;
        
        [SerializeField]
        private DungeonObject _blockArea;
        [SerializeField]
        private DungeonObject _coverObject;
        [SerializeField]
        private Transform _objectContainer;

        [SerializeField]
        private NavMeshSurface _navigationSurface;

        public Transform[] ClusterSlots => _clusterSlots;

        public DungeonObject HardWall => _blockArea;
        public DungeonObject SoftWall => _coverObject;
        public Transform ObjectContainer => _objectContainer;

        public NavMeshSurface NavigationSurface => _navigationSurface;
    }
}
