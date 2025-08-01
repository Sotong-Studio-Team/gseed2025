using SotongStudio.Bomber.Gameplay.DungeonGeneration.Data;
using SotongStudio.Bomber.Gameplay.DungeonObject;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonGeneration
{
    public interface IDngeonGenerationLogic
    {
        void GenerateDugeonObject(IDugeonGeneratedData generationData);
        void UpdateNavigationSurface();
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
        public void UpdateNavigationSurface()
        {
            _view.NavigationSurface.BuildNavMesh();
        }
        private void AddBlockTile(string clusterId, Vector2Int blockPosition)
        {
            var block = Object.Instantiate(_view.HardWall);
            block.name = $"{clusterId}";
            SetObjectPosition(block, blockPosition);

            block.InitializeProcess();
        }
        private void AddObject(IGeneratedObjectData objectData)
        {
            var isCovered = objectData.IsCovered;
            var coordinate = objectData.Coordinate;

            var config = _dungeonObjectConfigCollection.GetItem(objectData.ObjectId);
            var objPrefab = config.ObjectPrefab;

            var obj = Object.Instantiate(objPrefab);
            SetObjectPosition(obj, coordinate);

            obj.InitializeProcess();

            if(isCovered)
            {
                var dunObj = obj.GetComponent<IDungeonObject>(); 
                AddCoverStone(dunObj, coordinate);
                dunObj.ShowAsCovered();
            }
        }

        private void AddCoverStone(IDungeonObject dunObj, Vector2Int coordinate)
        {
            var softWall = Object.Instantiate(_view.SoftWall);
            SetObjectPosition(softWall, coordinate);
            softWall.InitializeProcess();

            if (softWall is not ISoftWallObject softWallLogic)
            {
                throw new System.Exception("Soft wall object must implement ISoftWallObject interface.");
            }

            softWallLogic.SetLinkedObject(dunObj);
        }

        private void SetObjectPosition(DungeonObject.DungeonObject obj, Vector2Int coordinate)
        {
            obj.transform.position = (Vector2)coordinate + _view.ZeroPosition;
            obj.transform.SetParent(_view.ObjectContainer);
        }
    }
}
