using NavMeshPlus.Components;
using SotongStudio.Bomber.Gameplay.DungeonObject;
using UnityEngine;

namespace SotongStudio.Bomber
{
    public interface IDungeonGenerationView
    {
        DungeonObject HardWall { get; }
        DungeonObject SoftWall { get; }
        Transform ObjectContainer { get; }

        NavMeshSurface NavigationSurface { get; }
        Vector2 ZeroPosition { get; }
        Vector3 PlayerStartPos { get; }
    }
    public class DungeonGenerationView : MonoBehaviour, IDungeonGenerationView
    {
        [SerializeField]
        private DungeonObject _blockArea;
        [SerializeField]
        private DungeonObject _coverObject;
        [SerializeField]
        private Transform _objectContainer;

        [SerializeField]
        private NavMeshSurface _navigationSurface;
        [SerializeField]
        private Transform _zeroPosition;
        [SerializeField]
        private Transform _playerStartPos;

        public DungeonObject HardWall => _blockArea;
        public DungeonObject SoftWall => _coverObject;
        public Transform ObjectContainer => _objectContainer;

        public NavMeshSurface NavigationSurface => _navigationSurface;

        public Vector2 ZeroPosition => _zeroPosition.position;
        public Vector3 PlayerStartPos => _playerStartPos.position;
    }
}
