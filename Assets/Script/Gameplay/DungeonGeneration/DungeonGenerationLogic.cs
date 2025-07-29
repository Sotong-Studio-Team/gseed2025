using SotongStudio.Bomber.Gameplay.DungeonGeneration.Data;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonGeneration
{
    public interface IDngeonGenerationLogic
    {
        void GenerateDugeonObject(IDugeonGeneratedData generationData);
    }
    public class DungeonGenerationLogic : IDngeonGenerationLogic
    {
        private readonly IDungeonGenerationView _view;

        public DungeonGenerationLogic(IDungeonGenerationView view)
        {
            _view = view;
        }

        public void GenerateDugeonObject(IDugeonGeneratedData generationData)
        {
            foreach (var cluster in generationData.GeneratedClusters)
            {
                foreach (var blockArea in cluster.BlockedTiles)
                {
                    AddBlockTile(cluster.ClusterId, blockArea);
                }
            }

            foreach (var dungeonObject in generationData.GeneratedObjects)
            {
                AddObject(dungeonObject.Coordinate, dungeonObject.IsCovered);
            }
        }

        private void AddBlockTile(string clusterId, Vector2Int blockArea)
        {
            var block = Object.Instantiate(_view.BlockTile);
            block.name = $"{clusterId}";
            block.transform.position = (Vector2)blockArea;
        }
        private void AddObject(Vector2Int coordinate, bool isCovered)
        {
            var block = Object.Instantiate(isCovered ? _view.DungeonObject : _view.CoverObject);
            block.transform.position = (Vector2)coordinate;
        }

    }
}
