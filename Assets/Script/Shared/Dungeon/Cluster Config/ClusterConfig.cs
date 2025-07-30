using System.Collections.Generic;
using SotongStudio.SharedData.PredefinedData;
using UnityEngine;

namespace SotongStudio.Bomber.Shared.Dungeon.Cluster
{
    public interface IClusterConfig : IPredefinedItem
    {
        IEnumerable<Vector2Int> EmptyTiles { get; }
        IEnumerable<Vector2Int> BlockedTiles { get; }
    }
    [CreateAssetMenu(menuName = "Config/Cluster", fileName = "CLU-000")]
    public class ClusterConfig : ScriptableObject, IClusterConfig
    {
        [SerializeField] private string _clusterId;
        [SerializeField] private GridVisualizer _gridVisual;

        public string ItemId => _clusterId;

        public IEnumerable<Vector2Int> EmptyTiles => _gridVisual.GetNonActiveCells();
        public IEnumerable<Vector2Int> BlockedTiles =>  _gridVisual.GetActiveCells();
    }
}
