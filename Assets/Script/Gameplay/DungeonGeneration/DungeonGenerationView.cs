using UnityEngine;

namespace SotongStudio.Bomber
{
    public interface IDungeonGenerationView
    {
        Transform[] ClusterSlots { get; }
        
        GameObject BlockTile { get; }
        GameObject CoverObject { get; }
    }
    public class DungeonGenerationView : MonoBehaviour, IDungeonGenerationView
    {
        [SerializeField]
        private Transform[] _clusterSlots;
        
        [SerializeField]
        private GameObject _blockArea;
        [SerializeField]
        private GameObject _coverObject;

        public GameObject BlockTile => _blockArea;
        public Transform[] ClusterSlots => _clusterSlots;
        public GameObject CoverObject => _coverObject;
    }
}
