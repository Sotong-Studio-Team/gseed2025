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
        private readonly IDungeonObjectConfigCollection _dungeonObjectConfigCollection;

        public DungeonGenerationLogic(IDungeonGenerationView view,
                                      IDungeonObjectConfigCollection dungeonObjectConfigCollection)
        {
            _view = view;
            _dungeonObjectConfigCollection = dungeonObjectConfigCollection;
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
                AddObject(dungeonObject);
            }
        }

        private void AddBlockTile(string clusterId, Vector2Int blockArea)
        {
            var block = Object.Instantiate(_view.BlockTile);
            block.name = $"{clusterId}";
            block.transform.position = (Vector2)blockArea;
        }
        private void AddObject(IGeneratedObjectData objectData)
        {
            var isCovered = objectData.IsCovered;
            var coordinate = objectData.Coordinate;

            var config = _dungeonObjectConfigCollection.GetItem(objectData.ObjectId);
            var objPrefab = config.ObjectPrefab;

            var block = Object.Instantiate(objPrefab);
            block.transform.position = (Vector2)coordinate;
        }

    }
}
