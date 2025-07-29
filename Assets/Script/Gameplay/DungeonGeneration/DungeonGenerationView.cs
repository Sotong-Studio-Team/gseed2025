using UnityEngine;

namespace SotongStudio.Bomber
{
    public interface IDungeonGenerationView
    {
        GameObject BlockTile { get; }
        public Transform[] ClusterSlots { get; }
        GameObject DungeonObject { get; }
        GameObject CoverObject { get; }
    }
    public class DungeonGenerationView : MonoBehaviour, IDungeonGenerationView
    {
        [SerializeField]
        private GameObject _blockArea;
        [SerializeField]
        private Transform[] _clusterSlots;
        [SerializeField]
        private GameObject _dungeonObject;
        [SerializeField]
        private GameObject _coverObject;

        public GameObject BlockTile => _blockArea;
        public Transform[] ClusterSlots => _clusterSlots;
        public GameObject DungeonObject => _dungeonObject;
        public GameObject CoverObject => _coverObject;
    }
}
