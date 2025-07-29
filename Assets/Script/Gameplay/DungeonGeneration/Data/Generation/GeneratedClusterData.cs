using System.Collections;
using System.Collections.Generic;
using SotongStudio.Bomber.Shared.Dungeon.Cluster;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonGeneration.Data
{
    public interface IGeneratedClusterData
    {
        string ClusterId { get; }
        ClusterRoationType Rotation { get; }
        Vector2Int LayoutIndex { get; }

        IEnumerable<Vector2Int> BlockedTiles { get; }
        IEnumerable<Vector2Int> EmptyTile { get; }
    }

    public enum ClusterRoationType
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3

    }
    public class GeneratedClusterData : IGeneratedClusterData
    {
        public string ClusterId { get; private set; }
        public ClusterRoationType Rotation { get; private set; }
        public Vector2Int LayoutIndex { get; private set; }

        public IEnumerable<Vector2Int> BlockedTiles { get; private set; }

        public IEnumerable<Vector2Int> EmptyTile { get; private set; }

        public GeneratedClusterData(string clusterId, ClusterRoationType rotation, Vector2Int layoutIndex,
                                    IEnumerable<Vector2Int> blockedTile,
                                    IEnumerable<Vector2Int> emptyTile)
        {
            ClusterId = clusterId;
            Rotation = rotation;
            LayoutIndex = layoutIndex;
            BlockedTiles = blockedTile;
            EmptyTile = emptyTile;
        }
    }
}
